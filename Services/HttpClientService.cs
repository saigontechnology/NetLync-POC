using NetlyncAPI.DTO;
using System.Security.Cryptography.X509Certificates;

namespace NetlyncAPI.Services
{
    public class HttpClientService : IHttpClientServiceImplementation
    {
        public async Task<Response> Execute(Request req)
        {
            return await GetHttpClient(req);
        }

        private async Task<Response> GetHttpClient(Request req)
        {

            using (X509Certificate2 certWithKey = X509Certificate2.CreateFromPemFile("es-inbound-testing.crt", "client.key"))
            {
                byte[] pfxRawData = certWithKey.Export(X509ContentType.Pfx, "123456");

                using (X509Certificate2 pfxCertWithKey = new X509Certificate2(pfxRawData, "123456", X509KeyStorageFlags.MachineKeySet))
                {
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = (a, b, c, d) => { return true; };
                    handler.ClientCertificates.Add(pfxCertWithKey);

                    using (var client = new HttpClient(handler))
                    using (var request = new HttpRequestMessage(HttpMethod.Get, req.Url))
                    {
                        var response = client.SendAsync(request).GetAwaiter().GetResult();
                        var responseContent = await response.Content.ReadAsStringAsync();

                        return new Response
                        {
                            HttpResponse = response,
                            ResponseBody = responseContent
                        };
                    }
                }
            }

        }
    }
}

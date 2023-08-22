using System.Security.Cryptography.X509Certificates;

namespace NetlyncAPI.Services
{
    public class CertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCert)
        {
            var cert = new X509Certificate2(Path.Combine("luly_cert.pfx"), "123456");
            if(clientCert.Thumbprint == cert.Thumbprint)
            {
                return true;
            }

            return false;
        }
    }
}

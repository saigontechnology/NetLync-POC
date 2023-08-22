using NetlyncAPI.DTO;

namespace NetlyncAPI.Services
{
    public interface IHttpClientServiceImplementation
    {
        Task<Response> Execute(Request req);
    }
}
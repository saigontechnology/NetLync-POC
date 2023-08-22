using NetlyncAPI.DTO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace NetlyncAPI.Services
{
    public interface IHealthCheckService
    {

        Task<HealthCheckResDTO> HealthCheck(HealthCheckReqDTO req);

    }
}

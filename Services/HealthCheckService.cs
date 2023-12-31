﻿using NetlyncAPI.DTO;
using Newtonsoft.Json;

namespace NetlyncAPI.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly string _url = "https://inbound.ez-es.net/healthCheck";
        private readonly IHttpClientServiceImplementation _httpClientService;

        public HealthCheckService(IHttpClientServiceImplementation httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<HealthCheckResDTO> HealthCheck(HealthCheckReqDTO req)
        {
            Request httpRequest = new Request();
            httpRequest.Url = _url;
            var httpResponse = await _httpClientService.Execute(httpRequest);

            var resonse = JsonConvert.DeserializeObject<HealthCheckResDTO>(httpResponse.ResponseBody) ?? new HealthCheckResDTO();

            resonse.status_details = string.IsNullOrEmpty(resonse.status_details) ? "This operation succeeded" : resonse.status_details;
            resonse.operator_reference = string.IsNullOrEmpty(resonse.operator_reference) ? "My reference" : resonse.operator_reference;
            return resonse;
        }
    }
}

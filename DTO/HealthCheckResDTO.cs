namespace NetlyncAPI.DTO
{
    public class HealthCheckResDTO
    {
        public int status_code { get; set; }
        public string status { get; set; }
        public string status_details { get; set; } = string.Empty;
        public string operator_reference { get; set; } = string.Empty;
    }
}

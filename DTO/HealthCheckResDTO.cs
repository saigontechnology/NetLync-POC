namespace NetlyncAPI.DTO
{
    public class HealthCheckResDTO
    {
        public int status_code { get; set; }
        public string status { get; set; }
        public string status_details { get; set; }
        public string operator_reference { get; set; }
    }
}

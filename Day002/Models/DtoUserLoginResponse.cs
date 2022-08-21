namespace Day002.Models
{
    public record DtoUserLoginResponse
    {
        public string token { get; set; }
        public string username { get; set; }
    }
}

namespace Day001.Models
{
    public record DtoAuthenticationResponse
    {
        public string token { get; set; }
        public string username { get; set; }
    }
}

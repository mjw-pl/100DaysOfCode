using System.ComponentModel.DataAnnotations;

namespace Day001.Models
{
    public record DtoUserCredentialsRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}

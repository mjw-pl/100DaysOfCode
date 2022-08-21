using System.ComponentModel.DataAnnotations;

namespace Day002.Models
{
    public record DtoUserLoginRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}

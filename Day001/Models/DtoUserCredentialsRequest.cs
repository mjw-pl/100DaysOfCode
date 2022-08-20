using System.ComponentModel.DataAnnotations;

namespace Day001.Models
{
    public class DtoUserCredentialsRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}

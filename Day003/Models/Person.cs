using System.ComponentModel.DataAnnotations;
using Day003.Validators;

namespace Day003.Models;

public class Person
{
    [Required]
    [MaxLength(50)]
    public string Fullname { get; set; }
    
    [PeselValidation]
    public string Pesel { get; set; }
}
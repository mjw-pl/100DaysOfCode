using System.ComponentModel.DataAnnotations;
using Day003.Tools;

namespace Day003.Validators;

public class PeselValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var pesel = value?.ToString();
        
        if (string.IsNullOrEmpty(pesel))
        {
            return new ValidationResult("Field is required" );
        }
        
        if (pesel.All(char.IsDigit) == false)
        {
            return new ValidationResult("Field must contain only digits" );
        }
        
        if (pesel.Length != 11)
        {
            return new ValidationResult("Field must contain 11 digits" );
        }

        if (PeselTool.IsValid(pesel))
        {
            return ValidationResult.Success;
        }
   
        return new ValidationResult("Number is incorrect" );
    }
}
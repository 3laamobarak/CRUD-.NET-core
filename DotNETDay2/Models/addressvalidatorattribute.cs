using System.ComponentModel.DataAnnotations;

namespace DotNETDay2.Models
{
    public class addressvalidatorAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Instructor inst = validationContext.ObjectInstance as Instructor;

            string address = value.ToString();
            if (address == "Cairo" || address == "Alex" || address == "Qena"||
                address == "cairo" || address == "alex" || address == "qena")
                return ValidationResult.Success;
            return new ValidationResult("Address must be cairo ,alex OR Qena");
        }
    }
}

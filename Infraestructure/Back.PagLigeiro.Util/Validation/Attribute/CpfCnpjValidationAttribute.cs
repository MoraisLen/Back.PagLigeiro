using System.ComponentModel.DataAnnotations;

namespace Back.PagLigeiro.Util.Validation.Attribute
{
    public class CpfCnpjValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value is not null && CpfCnpjValidation.IsValid(value.ToString())
                ? ValidationResult.Success
                : new ValidationResult($"O CPF/CNPJ é inválido.");
        }
    }
}

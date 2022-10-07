
using System.ComponentModel.DataAnnotations;
using Api.Models;

namespace Api.Validator
{
  public class UserExits : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      string Cpf = (string)value;

      DataContext context = (DataContext)validationContext.GetService(typeof(DataContext));
      return !context.UserModels.Any(users => users.Cpf.Equals(Cpf)) ? ValidationResult.Success : new ValidationResult("Esse funcionário já existe");
    }
  }
}
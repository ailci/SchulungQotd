using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Shared.Validations;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private IEnumerable<string> AllowedExtensions { get; set; }

    public AllowedExtensionsAttribute(string valideTypen)
    {
        AllowedExtensions = valideTypen.Split(',').Select(c => c.Trim().ToLower());
        ErrorMessage = $"Nur folgende Datei-Typen sind erlaubt: {string.Join(",", AllowedExtensions)}";
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        //MVC, RazorPages
        if (value is IFormFile formFile && !AllowedExtensions.Any(c => formFile.FileName.EndsWith(c)))
        {
            return new ValidationResult(ErrorMessage, [validationContext.MemberName ?? validationContext.DisplayName]);
        }

        return ValidationResult.Success;
    }
}

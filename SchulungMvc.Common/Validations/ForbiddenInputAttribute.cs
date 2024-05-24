using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchulungMvc.Common.ViewModels;

namespace SchulungMvc.Common.Validations
{
    public class ForbiddenInputAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly IEnumerable<string> _blackList;

        // [ForbiddenInput("admin,administrator,root,god"]
        public ForbiddenInputAttribute(string blackList) : base("Der Name ist nicht erlaubt") 
        {
            _blackList = blackList.Split(',').Select(c => c.Trim().ToLowerInvariant());
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var model = (AuthorCreateViewModel) validationContext.ObjectInstance; //ganze Objekt
            if (value is string tempName)
            {
                if (_blackList.Any(c => c == tempName.ToLowerInvariant())) //Eingabe in BlackList gefunden => Fehler
                {
                    return new ValidationResult("Der Name ist nicht erlaubt");
                }
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-forbiddeninput", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
            MergeAttribute(context.Attributes, "data-val-forbiddeninput-blacklist", string.Join(",", _blackList));
        }

        private void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            attributes.TryAdd(key, value);
        }
    }
}

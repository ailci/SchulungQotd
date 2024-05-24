using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungMvc.Common.ViewModels;

namespace SchulungMvc.Common.Validations
{
    public class ForbiddenInputAttribute : ValidationAttribute
    {
        private readonly IEnumerable<string> _blackList;

        // [ForbiddenInput("admin,administrator,root,god"]
        public ForbiddenInputAttribute(string blackList)
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungMvc.Common.Validations
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        public NoFutureDateAttribute() : base("Das Datum ist ungültig")
        { }
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //if (value is null) return new ValidationResult("Date is not set");

            if (value is not null && value is DateOnly dateToCheck)
            {
                if (dateToCheck <= DateOnly.FromDateTime(DateTime.Today)) return ValidationResult.Success;

                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            return ValidationResult.Success;
        }
    }
}

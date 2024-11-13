using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchulungQotd.Shared.Models;

namespace SchulungQotd.Shared.Validations
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var obj = (AuthorForCreateViewModel) validationContext.ObjectInstance;
            if (value is DateOnly dateToCheck)
            {
                if (dateToCheck > DateOnly.FromDateTime(DateTime.Today))
                    return new ValidationResult("Datum ist in der Zukunft");
            }

            return ValidationResult.Success;
        }
    }
}

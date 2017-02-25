using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCatalogMVC.Models
{
    public class ValidateDateRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var convertedDate = (DateTime)value;

            if (convertedDate >= Convert.ToDateTime("01/01/1920") && convertedDate <= Convert.ToDateTime("01/01/2020"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not in given range.");
            }
        }
    }
}
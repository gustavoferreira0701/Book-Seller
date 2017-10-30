using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksSeller.WebApi.Helpers
{
    public class BookValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Models.Book currentBook = (Models.Book)validationContext.ObjectInstance;
            
            return base.IsValid(value, validationContext);
        }
    }
}
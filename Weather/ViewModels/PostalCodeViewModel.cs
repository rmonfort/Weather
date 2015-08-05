using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.ViewModels
{
    public class PostalCodeViewModel
    {
        [DisplayName("Postal Code")]
        [Required]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "The value in the {0} field is not a valid US postal code.")]
        public int? PostalCode { get; set; }
    }
}
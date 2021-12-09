using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCountry.Models
{
    public class Country
    {
            [Required]
            [StringLength(2, MinimumLength = 2)]
            [RegularExpression(@"[A-Z]+", ErrorMessage = "Only upper case characters are allowed.")]
            [Display(Name = "Code")]
            public string ID { get; set; }

            // [Required]
            [Display(Name = "Continent")]
            // [StringLength(2, MinimumLength = 2)]
            // [RegularExpression(@"[A-Z]+", ErrorMessage = "Only upper case characters are allowed.")]
            public string ContinentID { get; set; }

            [Required]
            public string Name { get; set; }

            [Range(1, 10000000000)]
            [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
            public int? Population { get; set; }

            public int? Area { get; set; }

            [Display(Name = "UN Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
            // [Range(typeof(DateTime), "10/24/1945", "1/1/2100", ErrorMessage = "The United Nations was created 10/24/1945.")]
            [DataType(DataType.Date)]
            public DateTime? UnitedNationsDate { get; set; }

            public Continent Continent { get; set; }
        }
}

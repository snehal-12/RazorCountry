using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCountry.Models
{
    public class CountryStat:Country
    {
        [Display(Name = "Ppl/SqMi")]
        public float? Density { get; set; }
    }
}

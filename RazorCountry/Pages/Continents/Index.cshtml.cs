using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;
using RazorCountry.Data;

namespace RazorCountry.Pages.Continents
{
    public class IndexModel : PageModel
    {
        private readonly RazorCountryContext _context;

        public IndexModel(RazorCountryContext context)
        {
            _context = context;
        }

        public List<Continent> Continents { get; set; }

        public async Task OnGetAsync()
        {
            Continents = await _context.Continents.ToListAsync();
        }

    }
}
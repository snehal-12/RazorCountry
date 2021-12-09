using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;
using RazorCountry.Data;

namespace RazorCountry.Pages.Continents
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCountryContext _context;

        public DeleteModel(RazorCountryContext context)
        {
            _context = context;
        }

        public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Continent = await _context.Continents
              .Include(c => c.Countries)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            if (Continent == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            //Find the continent using this query
            Continent Continent = await _context.Continents.FindAsync(id);
            //Delete the continent
            if (Continent != null)
            {
                _context.Continents.Remove(Continent);
            }
            //Persist the deletion
            await _context.SaveChangesAsync();
            //Redirect the user
            return RedirectToPage("./Index");
        }
    }
}
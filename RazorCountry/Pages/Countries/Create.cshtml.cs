using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCountry.Data;
using RazorCountry.Models;

namespace RazorCountry.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private readonly RazorCountry.Data.RazorCountryContext _context;

        public CreateModel(RazorCountry.Data.RazorCountryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ContinentID"] = new SelectList(_context.Continents, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Countries.Add(Country);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

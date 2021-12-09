﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;
using RazorCountry.Data;
using System.Linq;

namespace RazorCountry.Pages.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCountryContext _context;

        public DeleteModel(RazorCountryContext context)
        {
            _context = context;
        }

        public CountryStat Country { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var country = from c in _context.Countries
                          where c.ID == id
                          select new CountryStat
                          {
                              ID = c.ID,
                              ContinentID = c.ContinentID,
                              Name = c.Name,
                              Population = c.Population,
                              Area = c.Area,
                              UnitedNationsDate = c.UnitedNationsDate,
                              Density = c.Population / c.Area
                          };

            Country = await country.SingleOrDefaultAsync();

            if (Country == null)
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
            //Find the Row to be deleted
            Country Country = await _context.Countries.FindAsync(id);
            //Delete the country row
            if (Country != null)
            {
                _context.Countries.Remove(Country);
            }
            //Persist the changes
            await _context.SaveChangesAsync();
            //Redirect the user
            return RedirectToPage("./Index");

        }
    }
}
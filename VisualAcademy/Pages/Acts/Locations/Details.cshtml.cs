﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models;

namespace VisualAcademy.Pages.Acts.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly VisualAcademy.Data.ApplicationDbContext _context;

        public DetailsModel(VisualAcademy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Locations
                .Include(l => l.PropertyRef).FirstOrDefaultAsync(m => m.Id == id);

            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

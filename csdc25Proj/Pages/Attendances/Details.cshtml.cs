using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csdc25Proj.Data;
using csdc25Proj.Models;

namespace csdc25Proj.Pages.Attendances
{
    public class DetailsModel : PageModel
    {
        private readonly csdc25Proj.Data.csdc25ProjContext _context;

        public DetailsModel(csdc25Proj.Data.csdc25ProjContext context)
        {
            _context = context;
        }

      public Attendance Attendance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FirstOrDefaultAsync(m => m.id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            else 
            {
                Attendance = attendance;
            }
            return Page();
        }
    }
}

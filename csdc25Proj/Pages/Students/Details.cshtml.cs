using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csdc25Proj.Data;
using csdc25Proj.Models;

namespace csdc25Proj.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly csdc25Proj.Data.csdc25ProjContext _context;

        public DetailsModel(csdc25Proj.Data.csdc25ProjContext context)
        {
            _context = context;
        }

      public Student Students { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Students == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

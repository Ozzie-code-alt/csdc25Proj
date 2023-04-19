using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csdc25Proj.Data;
using csdc25Proj.Models;

namespace csdc25Proj.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly csdc25Proj.Data.csdc25ProjContext _context;

        public DetailsModel(csdc25Proj.Data.csdc25ProjContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            Course = await _context.Courses
      .AsNoTracking()
      .Include(c => c.Department)
      .FirstOrDefaultAsync(m => m.CourseID == id);
            if (Course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = Course;
            }
            return Page();
        }
    }
}

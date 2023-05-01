using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using csdc25Proj.Data;
using csdc25Proj.Models;
using Microsoft.EntityFrameworkCore;

namespace csdc25Proj.Pages.Attendances
{
    public class CreateModel : PageModel
    {
        private readonly csdc25Proj.Data.csdc25ProjContext _context;

        public CreateModel(csdc25Proj.Data.csdc25ProjContext context)
        {
            _context = context;
        }

    /*    public IActionResult OnGet()
        {

            return Page();
        }*/

        [BindProperty]
        public Attendance Attendance { get; set; }
        public List<Student> Students { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
         
            _context.Attendance.Add(Attendance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");
        }
        public async Task OnGetAsync()
        {

            Students = await _context.Students.ToListAsync();
          
        }
    }
}

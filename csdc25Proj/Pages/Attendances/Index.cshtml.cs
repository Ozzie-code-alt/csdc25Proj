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
    public class IndexModel : PageModel
    {
        private readonly csdc25Proj.Data.csdc25ProjContext _context;

        public IndexModel(csdc25Proj.Data.csdc25ProjContext context)
        {
            _context = context;
        }

        
        public IList<Attendance> Attendance { get;set; }
        public List<Student> Students { get; set; }
        public async Task OnGetAsync()
        {
        
            Students = await _context.Students.ToListAsync();
            if (_context.Attendance != null)
            {
                Attendance = await _context.Attendance.ToListAsync();
            }
        }
   
    }
}

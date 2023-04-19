using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // no brainer references

namespace csdc25Proj.Models.SchoolViewModels
{
    public class InstructorIndexData
    {


        // calling out other models for fetching data 
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }


    }
}

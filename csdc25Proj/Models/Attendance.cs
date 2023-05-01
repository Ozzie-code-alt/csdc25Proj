using System.ComponentModel.DataAnnotations;

namespace csdc25Proj.Models
{
    public class Attendance
    {
        [Key]
        public int id { get; set; }

        public string StudentName { get; set; }

        public string isPresent { get; set; }

        public DateTime currDate { get; set; }

       
    }
}

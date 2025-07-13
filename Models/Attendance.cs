
using System.ComponentModel.DataAnnotations;

namespace FFCProject.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }  // e.g., Present, Absent, Leave
    }
}

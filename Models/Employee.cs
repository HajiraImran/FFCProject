using System.ComponentModel.DataAnnotations;

namespace FFCProject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string ContactNumber { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }


    }
}

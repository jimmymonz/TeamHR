using System.ComponentModel.DataAnnotations;

namespace TeamHR.DAO
{
    public class EmployeeEntity
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace teamhr_api.DAO
{
    public class EmployeeEntity
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public DepartmentEntity Department { get; set; } = new DepartmentEntity();
    }
}
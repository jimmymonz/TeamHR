using System.ComponentModel.DataAnnotations;

namespace teamhr_api.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }
    }
}

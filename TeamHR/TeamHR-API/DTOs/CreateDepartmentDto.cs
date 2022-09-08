using System.ComponentModel.DataAnnotations;

namespace teamhr_api.DTOs
{
    public class CreateDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentDescription { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace teamhr_api.DTOs
{
    public class DepartmentDto
    {
        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentDescription { get; set; }
    }
}

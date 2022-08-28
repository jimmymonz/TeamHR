using System.ComponentModel.DataAnnotations;

namespace teamhr_api.DAO
{
    public class DepartmentEntity
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentDescription { get; set; }
    }
}

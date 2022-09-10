using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.Domains
{
    public class Dept
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? DeptName { get; set; }

    }
}

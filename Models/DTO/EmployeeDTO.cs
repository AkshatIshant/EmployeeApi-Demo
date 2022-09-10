using EmployeeAPI.Models.Domains;

namespace EmployeeAPI.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public double Esalary { get; set; }

        public int DeptId { get; set; }
        public DeptDTO Dept { get; set; }
    }
}

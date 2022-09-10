using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeAPI.Models.Domains
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public double Esalary { get; set; }
      
        public int DeptId { get; set; }
        public Dept Dept { get; set; }
      
    }
}

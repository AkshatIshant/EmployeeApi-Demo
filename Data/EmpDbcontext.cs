
using EmployeeAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmpDbcontext : DbContext
    {
        public EmpDbcontext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Dept>Depts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}


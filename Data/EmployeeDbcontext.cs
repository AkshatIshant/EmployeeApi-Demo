using EmployeeAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbcontext :DbContext
    {
       
            public  EmployeeDbcontext(DbContextOptions options):base(options)
            { 
                
            }

            public DbSet<Dept> Departments { get; set; }
           public DbSet<Employee> Employees { get; set; }
    }

    
}

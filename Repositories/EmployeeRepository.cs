using EmployeeAPI.Data;
using EmployeeAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbcontext empDbcontext;
        public EmployeeRepository(EmpDbcontext _empDbcontext)
        {
            empDbcontext = _empDbcontext;
        }

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    //  throw new NotImplementedException();
        //    return empDbcontext.Employees.ToList();
        //}

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            //  throw new NotImplementedException();
            return await empDbcontext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            //  throw new NotImplementedException();
            //return empDbcontext.Employees.Where(x => x.Id==id).Single(); sync
            return await empDbcontext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            //throw new NotImplementedException();
            await empDbcontext.Employees.AddAsync(employee); 
            await empDbcontext.SaveChangesAsync();
            return employee;

        }
        public async Task<Employee> DeleteEmployeeAsync(int id)
        {

           var emp= await empDbcontext.Employees.SingleAsync(x => x.Id == id);

            if (emp == null)
            {
                return null;
            }
            else
            {
                empDbcontext.Remove(emp);
                await empDbcontext.SaveChangesAsync();
            }
            return emp;
            

        }

        public async Task<Employee> UpdateEmployeeAsync(int empId, Employee emps)
        {
            var emp = await empDbcontext.Employees.Where(x=> x.Id== empId).SingleAsync();
            emp.EmpName = emps.EmpName;
            emp.Esalary = emps.Esalary;
            emp.DeptId = emps.DeptId;
            
            empDbcontext.Employees.Update(emp) ;
            empDbcontext.SaveChangesAsync();
            return emp;

            //throw new NotImplementedException();
            //var emp = await empDbcontext.Employees.SingleAsync(x => x.Id == id);

            //if (emp == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    empDbcontext.Update(emp);
            //    await empDbcontext.SaveChangesAsync();
            //}
            //return emp;

        }
    }
          
           
 }

 

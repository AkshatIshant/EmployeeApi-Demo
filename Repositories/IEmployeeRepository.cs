using EmployeeAPI.Models.Domains;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        //IEnumerable<Employee> GetEmployees(); synchronous
       Task< IEnumerable<Employee>> GetEmployeesAsync(); //asyncronous
        // Employee GetEmployee(int id);
       Task< Employee> GetEmployeeAsync(int id);
        Task< Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int empId, Employee emps);
    }
}

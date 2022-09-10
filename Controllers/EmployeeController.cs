using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Models.Domains;
using EmployeeAPI.Models.DTO;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public EmployeeController(IEmployeeRepository _employeeRepository, IMapper _mapper)
        {
            employeeRepository = _employeeRepository;
            mapper = _mapper;
        }
        // [HttpGet]
        //public IActionResult Get()
        // {



        // var allEmps = employeeRepository.GetEmployees(); //sync


        //return Ok(allEmps);

        //using DTO classses to expose without AutoMapper
        /* var employeeDTO = new List<Models.DTO.EmployeeDTO>();
        allEmps.ToList().ForEach(emp =>
            {
                var empDTO = new Models.DTO.EmployeeDTO()
                {
                    Id = emp.Id,
                    EmpName = emp.EmpName,
                    Esalary = emp.Esalary,
                    DeptId = emp.DeptId,
                };
                employeeDTO.Add(empDTO);
            });
        return Ok(employeeDTO); 
        */


        //using DTO classses to expose without AutoMapper
        [HttpGet]
        public async Task<IActionResult> GetEmpsAsync()
        {
            var allEmps = await employeeRepository.GetEmployeesAsync();
            var empDTO = mapper.Map<List<EmployeeDTO>>(allEmps);
            return Ok(empDTO);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {



            var EmpById = await employeeRepository.GetEmployeeAsync(id);
            var empDTO = mapper.Map<EmployeeDTO>(EmpById);
            return Ok(empDTO);

        }
        [HttpPost]
        public async Task<IActionResult> AddEmpAsync(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var empModel = new Employee()
                {

                    EmpName = emp.EmpName,
                    Esalary = emp.Esalary,
                    DeptId = emp.DeptId,

                };
                emp = await employeeRepository.AddEmployeeAsync(empModel);

                var empDTO = mapper.Map<EmployeeDTO>(emp);

                return Ok(empDTO);
                //DTO
                //var empDTO = new EmployeeDTO()
                //{
                //    EmpName = emp.EmpName,
                //    Esalary = emp.Esalary,
                //    DeptId = emp.DeptId,
                //};
                // return CreatedAtAction("GetEmpsAsync", new Employee{ Id =empDTO.Id });
            }
        }
        [HttpDelete("empId")]
        public async Task<IActionResult> DeleteEmployeeAsync(int empId)
        {
            var emp = await employeeRepository.DeleteEmployeeAsync(empId);
            if (emp == null)
            {
                return NoContent();
            }
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            return Ok(empDTO);
        }
        [HttpPut("empId")]
        public async Task<IActionResult> UpdateEmployeeAsync(int empId, Employee emps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var emp = await employeeRepository.UpdateEmployeeAsync(empId, emps);
                var empdata = mapper.Map<Employee>(emp);
                return Ok(empdata);


            }
        }
    }
}






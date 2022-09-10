using AutoMapper;
using EmployeeAPI.Models.Domains;
using EmployeeAPI.Models.DTO;
namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
        }
    }
}

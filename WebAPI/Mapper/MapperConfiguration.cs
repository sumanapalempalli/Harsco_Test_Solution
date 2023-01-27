using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapper
{
    public class MapperConfiguration:Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee,GetEmployeeDto>().ReverseMap();
            CreateMap<Employee,UpdateDTO>().ReverseMap();   
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;
using WebAPI.Contracts;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class EmployeeRepository:IEmployee
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDbContext employeeDbContext,IMapper mapper)
        {
            this._employeeDbContext = employeeDbContext;
            this._mapper = mapper;
        }
        public async Task<List<Employee>> GetAllEmployeeDetails()
        {
            return await _employeeDbContext.Employees.ToListAsync();

        }

        public async Task<Employee> GetEmployeeDetailsById(int id)
        {
            return  await _employeeDbContext.Employees.FindAsync(id);
            
        }

        public async Task<bool> CreateEmployeeForm(Employee emp)
        {

            var result = await _employeeDbContext.Employees.AddAsync(emp);
            await _employeeDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateEmployeeDetails(int id,Employee employee)
        {
            var result = await _employeeDbContext.Employees.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _mapper.Map(employee, result);
            _employeeDbContext.ChangeTracker.Clear();


            _employeeDbContext.Update<Employee>(employee);

            await _employeeDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteEmployeeDetails(int id)
        {
            var result = await _employeeDbContext.Employees.FindAsync(id);
            if (result == null)
            {
                return false;
            }
             _employeeDbContext.Remove(result);
            await _employeeDbContext.SaveChangesAsync();
            return true;

        }





        



        

        
    }
}

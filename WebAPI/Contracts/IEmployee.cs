using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Contracts
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployeeDetails();

        Task<Employee> GetEmployeeDetailsById(int id);

        Task<bool> CreateEmployeeForm(Employee employee);

        Task<bool> UpdateEmployeeDetails(int id,Employee employee);

        Task<bool> DeleteEmployeeDetails(int id);
    }
}

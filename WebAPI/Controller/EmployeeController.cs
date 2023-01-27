using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployee employeeRepository,IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetEmployeeDetails()
        {
            var details = await  _employeeRepository.GetAllEmployeeDetails();
            if (details == null)
            {
                return Forbid("details are empty");
            }

            var mapRecords=_mapper.Map<List<GetEmployeeDto>>(details);

            return Ok(mapRecords);
        }
        [HttpPost]
        [Route("CreateEmployeeDetails")]
        public async Task<ActionResult<bool>> CreateEmployeeDetails([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest("Employee form is null");
            }
            if (ModelState.IsValid)
            {
                var employeeDOBYear = employeeDTO.DOB.Year;
                var currentYear = DateTime.Now.Year;
                if(currentYear-employeeDOBYear < 18)
                {
                    return BadRequest("Age must be gretaer than 18");
                }


                var mapForm = _mapper.Map<Employee>(employeeDTO);
                var createdForm = await _employeeRepository.CreateEmployeeForm(mapForm);
                return Ok(createdForm);
            }
               
            
            return BadRequest("Request Not Valid");

           
        }


        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public async Task<ActionResult<bool>> UpdateEmployeeDetails(UpdateDTO updateDTO)
        {

            if (updateDTO.Id == 0)
            {
                return BadRequest("Id is null");
            }
            var employeeDOBYear = updateDTO.DOB.Year;
            var currentYear = DateTime.Now.Year;
            if (currentYear - employeeDOBYear < 18)
            {
                return BadRequest("Age must be gretaer than 18");
            }
            var mapInfo = _mapper.Map<Employee>(updateDTO);
            var employee = await _employeeRepository.UpdateEmployeeDetails(updateDTO.Id,mapInfo);
            if (employee == false)
            {
                return NotFound("Employee Not Updated");
            }

            return Ok(employee);

        }

        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public async Task<ActionResult<bool>> DeleteEmployeeDetails(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is null");
            }

            var employee = await _employeeRepository.DeleteEmployeeDetails(id);
            if (employee == false)
            {
                return NotFound("Employee Not Updated");
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<ActionResult<GetEmployeeDto>> GetEmployeeById(int id)
        {
            if (id == 0 || id <0)
            {
                return BadRequest("id is null");
            }
            var employee=await _employeeRepository.GetEmployeeDetailsById(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m2sys.Infrastructure.DataModel;
using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace m2sys.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-all-employee")]
  
        public IActionResult Get()
        {
            // return Ok(index);
            try
            {
                var result = new ResultModel<IEnumerable<EmployeeDTO>>
                {
                    Data = _employeeService.GetEmployees(),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch(Exception ex)
            {
                var result = new ResultModel<IEnumerable<EmployeeDTO>>
                {
                    Data = _employeeService.GetEmployees(),
                    Message = "Error Occurred",
                    Success = false
                };

                return Ok(result);
            }

        }

        [HttpGet("get-all-employee-pagination/{pageIndex}/{pageSize}")]
        public IActionResult GetPagination(int pageIndex, int pageSize)
        {
            // return Ok(index);
            try
            {
                var result = new ResultModel<IEnumerable<EmployeeDTO>>
                {
                    Data = _employeeService.GetEmployeesByPagination(pageIndex, pageSize),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ResultModel<IEnumerable<EmployeeDTO>>
                {
                    Data = _employeeService.GetEmployees(),
                    Message = "Error Occurred",
                    Success = false
                };

                return Ok(result);
            }

        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateProject(EmployeeDTO employee)
        {
            try
            {
                await _employeeService.CreateEmployee(employee);

                var result = new ResultModel<EmployeeDTO>
                {
                    Data = null,
                    Message = "Employee has been created successfully",
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
               

                var result = new ResultModel<EmployeeDTO>
                {
                    Data = new EmployeeDTO(),
                    Message = "Error Occurred",
                    Success = false
                };

                return BadRequest(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = new ResultModel<EmployeeDTO>
                {
                    Data = _employeeService.GetEmployeeById(id),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ResultModel<EmployeeDTO>
                {
                    Data = new EmployeeDTO(),
                    Message = $"Error: {ex.Source}",
                    Success = false
                };

                return BadRequest(result);
            }
        }

        [HttpDelete("delete-employee-by-id/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _employeeService.DeleteEmployeeRecord(id);
                var finalResult = new ResultModel<EmployeeDTO>
                {
                    Data = null,
                    Message = result ? string.Empty : "Error Occurred",
                    Success = result
                };

                return Ok(finalResult);
            }
            catch (Exception ex)
            {

                var result = new ResultModel<EmployeeDTO>
                {
                    Data = new EmployeeDTO(),
                    Message = "Error Occurred",
                    Success = false
                };

                return BadRequest(result);
            }
        }

        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                await _employeeService.UpdateEmployee(employee);

                var result = new ResultModel<EmployeeDTO>
                {
                    Data = new EmployeeDTO(),
                    Message = "Update successful",
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {


                var result = new ResultModel<EmployeeDTO>
                {
                    Data = new EmployeeDTO(),
                    Message = "Error Occurred",
                    Success = false
                };

                return BadRequest(result);
            }
        }


        }
}

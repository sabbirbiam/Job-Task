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
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("get-all-leave-pagination/{pageIndex}/{pageSize}")]
        public IActionResult GetLeaveByPagination(int pageIndex, int pageSize)
        {
            try
            {
                var result = new ResultModel<IEnumerable<LeaveDTO>>
                {
                    Data = _leaveService.GetLeavesJoin(pageIndex, pageSize),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ResultModel<IEnumerable<LeaveDTO>>
                {
                    Data = _leaveService.GetLeaves(),
                    Message = "Error Occurred",
                    Success = false
                };

                return Ok(result);
            }

        }

        [HttpGet("get-all-leaves")]
        public IActionResult Get()
        {
            try
            {
                var result = new ResultModel<IEnumerable<LeaveDTO>>
                {
                    Data = _leaveService.GetLeaves(),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ResultModel<IEnumerable<LeaveDTO>>
                {
                    Data = _leaveService.GetLeaves(),
                    Message = "Error Occurred",
                    Success = false
                };

                return Ok(result);
            }

        }

        [HttpPost("create-leave")]
        public async Task<IActionResult> Createleave(LeaveDTO leave)
        {

            try
            {
                await _leaveService.CreateLeave(leave);

                var result = new ResultModel<LeaveDTO>
                {
                    Data = null,
                    Message = "Leave has been created successfully",
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ResultModel<LeaveDTO>
                {
                    Data = new LeaveDTO(),
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
                var result = new ResultModel<LeaveDTO>
                {
                    Data = _leaveService.GetLeaveById(id),
                    Message = string.Empty,
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                var result = new ResultModel<LeaveDTO>
                {
                    Data = new LeaveDTO(),
                    Message = $"Error: {ex.Source}",
                    Success = false
                };

                return BadRequest(result);
            }
        }

        [HttpDelete("delete-leave-by-id/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _leaveService.DeleteLeaveRecord(id);
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

        [HttpPut("update-leave")]
        public async Task<IActionResult> UpdateLeave(LeaveDTO leave)
        {
            try
            {
                await _leaveService.UpdateLeave(leave);

                var result = new ResultModel<LeaveDTO>
                {
                    Data = new LeaveDTO(),
                    Message = "Update successful",
                    Success = true
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                

                var result = new ResultModel<LeaveDTO>
                {
                    Data = new LeaveDTO(),
                    Message = "Error Occurred",
                    Success = false
                };

                return BadRequest(result);
            }
        }
    }
}

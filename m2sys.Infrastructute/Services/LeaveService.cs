using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Entities;
using m2sys.Infrastructute.Services.Interface;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m2sys.Infrastructute.Services
{
    
    public class LeaveService: ILeaveService
    {
        private readonly IApiUnitOfWork _apiUnitOfWork;
        private ApiContext _apiContext;

        public LeaveService(IApiUnitOfWork apiOfWork, ApiContext apiContext)
        {
            _apiUnitOfWork = apiOfWork;
            _apiContext = apiContext;
        }

        public IEnumerable<LeaveDTO> GetLeaves()
        {
            var data = _apiUnitOfWork.LeaveRepository.GetAll();
            if (data == null)
            {
                // _loggingService.AddLoggingMessage("No data found in Screen Capture Table.");
                return null;
            }

            var result = data.Select(x => new LeaveDTO
            {
                Id = x.Id,
                EmployeeId = x.EmployeeId,
                LeaveType = x.LeaveType,
                Description = x.Description,
                StrarDate = x.StrarDate,
                EndDate = x.EndDate
            });

            return result;
        }

        public async Task CreateLeave(LeaveDTO leave)
        {
          
            var newLeave = new Leave
            {
                EmployeeId = leave.EmployeeId,
                LeaveType = leave.LeaveType,
                Description = leave.Description,
                StrarDate = leave.StrarDate,
                EndDate = leave.EndDate,
            };

            _apiUnitOfWork.LeaveRepository.Add(newLeave);
            await _apiUnitOfWork.SaveChangesAsync();
        }

        public LeaveDTO GetLeaveById(Guid id)
        {
            var data = _apiUnitOfWork.LeaveRepository.GetById(id);

            if (data == null)
            {
                // _loggingService.AddLoggingMessage($"No data exist in Active Window Database with the id: {id}");
                return null;
            }

            return new LeaveDTO()
            {
                Id = data.Id,
                EmployeeId = data.EmployeeId,
                LeaveType = data.LeaveType,
                Description = data.Description,
                StrarDate = data.StrarDate,
                EndDate = data.EndDate
            };
        }

          public bool DeleteLeaveRecord(Guid id)
        {
            var data = _apiUnitOfWork.LeaveRepository.GetById(id);

            if (data == null)
            {
                //_loggingService.AddLoggingMessage($"No data exist in Active Window Database with the Id: {id}");
                return false;
            }

            _apiUnitOfWork.LeaveRepository.Remove(data);
            _apiUnitOfWork.SaveChanges();
            return true;
        }

        public async Task UpdateLeave(LeaveDTO leave)
        {
            var leaveUpdate = _apiUnitOfWork.LeaveRepository.GetById(leave.Id);
            if (leaveUpdate == null)
                throw new Exception($"No leave has found for update with Id: {leave.Id}");


            leaveUpdate.EmployeeId = leave.EmployeeId;
            leaveUpdate.Description = leave.Description;
            leaveUpdate.LeaveType = leave.LeaveType;
            leaveUpdate.StrarDate = leave.StrarDate;
            leaveUpdate.EndDate = leave.EndDate;

            _apiUnitOfWork.LeaveRepository.Edit(leaveUpdate);
            await _apiUnitOfWork.SaveChangesAsync();
        }



        void ILeaveService.getAll()
        {
            //_apiUnitOfWork.LeaveRepository.
            throw new NotImplementedException();
        }

        public IList<LeaveDTO> GetLeavesJoin(int pageIndex, int pageSize)
        {
            var result = (from le in _apiContext.Leaves
                          join em in _apiContext.Employees on le.EmployeeId equals em.Id
                          select new LeaveDTO
                          {
                              Id = le.Id,
                              EmployeeId = em.Id,
                              Description = le.Description,
                              LeaveType = le.LeaveType,
                              StrarDate = le.StrarDate,
                              EndDate = le.EndDate,
                              EmpName = em.FirstName
                          }).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return result.ToList();

            //throw new NotImplementedException();
        }
    }

  
}

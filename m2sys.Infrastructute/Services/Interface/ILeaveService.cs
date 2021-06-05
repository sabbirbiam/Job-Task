using m2sys.Infrastructute.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace m2sys.Infrastructute.Services.Interface
{
    public interface ILeaveService
    {
        IEnumerable<LeaveDTO> GetLeaves();
        Task CreateLeave(LeaveDTO leave);
        LeaveDTO GetLeaveById(Guid Id);
        bool DeleteLeaveRecord(Guid Id);
        Task UpdateLeave(LeaveDTO leave);
        void getAll();
    }
}

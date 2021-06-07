using m2sys.core;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Repositories.Interface
{
    public interface ILeaveRepository : IRepository<Leave, Guid, ApiContext>
    {
        IList<LeaveDTO> GetLeavesJoin();
    }
}

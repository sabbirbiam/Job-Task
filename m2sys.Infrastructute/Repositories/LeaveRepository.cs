using m2sys.core;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.Entities;
using m2sys.Infrastructute.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Repositories
{
    public class LeaveRepository: Repository<Leave, Guid, ApiContext>, ILeaveRepository
    {
        private readonly ILeaveRepository _leaveRepository;
        public LeaveRepository(ApiContext apiContext, ILeaveRepository leaveRepository)
         : base(apiContext)
        {
            _leaveRepository = leaveRepository;
        }

        public IList<Leave> GetAllLevesByPagination()
        {
            throw new NotImplementedException();
        }
    }
}

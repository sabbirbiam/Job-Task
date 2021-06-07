using m2sys.core;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Entities;
using m2sys.Infrastructute.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Repositories
{
    public class LeaveRepository: Repository<Leave, Guid, ApiContext>, ILeaveRepository
    {

        private ApiContext _apiContext;
        public LeaveRepository(ApiContext apiContext)
         : base(apiContext)
        {
             _apiContext = apiContext;
        }

        public IList<Leave> GetAllLevesByPagination()
        {
            throw new NotImplementedException();
        }

        public IList<LeaveDTO> GetLeavesJoin()
        {
            //var entryPoint = (from le in _apiContext.Employees
            //                  join em in _apiContext.Leaves on le.EmployeeId equals em.Id
            //                  select new
            //                  { 
            //                  }).Take(10);
            throw new NotImplementedException();
        }
    }
}

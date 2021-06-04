using m2sys.core;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.Repositories.Interface;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.UnitOfWorks
{
    public class ApiUnitOfWork : UnitOfWork, IApiUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ILeaveRepository LeaveRepository { get; set; }

        public ApiUnitOfWork(ApiContext context,
           IEmployeeRepository employeeRepository,
           ILeaveRepository leaveRepository)
           : base(context)
        {
            EmployeeRepository = employeeRepository;
            LeaveRepository = leaveRepository;
        }

    }
}

using m2sys.core;
using m2sys.Infrastructute.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.UnitOfWorks.Interface
{
    public interface IApiUnitOfWork: IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        ILeaveRepository LeaveRepository { get; set; }
    }
}

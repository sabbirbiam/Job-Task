using m2sys.core;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Repositories.Interface
{
    public interface IEmployeeRepository : IRepository<Employee, Guid, ApiContext>
    {
    }
}

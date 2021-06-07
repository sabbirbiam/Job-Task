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
    public class EmployeeRepository: Repository<Employee, Guid, ApiContext>, IEmployeeRepository
    {
        public EmployeeRepository(ApiContext apiContext)
           : base(apiContext)
        {

        }

        public IList<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeDTO> GetEmployeeByPagination()
        {
            throw new NotImplementedException();
        }
    }
}

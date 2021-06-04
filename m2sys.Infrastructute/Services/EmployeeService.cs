using m2sys.Infrastructute.Entities;
using m2sys.Infrastructute.Services.Interface;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IApiUnitOfWork _apiUnitOfWork;
        public EmployeeService(IApiUnitOfWork apiUnitOfWork)
        {
            _apiUnitOfWork = apiUnitOfWork;
        }

        public IList<Employee> GetEmployees()
        {
            //return _apiUnitOfWork.EmployeeRepository.ge
            return null;
        }
    }
}

using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace m2sys.Infrastructute.Services.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        IEnumerable<EmployeeDTO> GetEmployeesByPagination(int index, int pageSize);
        Task CreateEmployee(EmployeeDTO employee);
        EmployeeDTO GetEmployeeById(Guid Id);
        bool DeleteEmployeeRecord(Guid Id);
        Task UpdateEmployee(EmployeeDTO employee);

    }
}

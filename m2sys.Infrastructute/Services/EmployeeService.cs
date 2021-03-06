using m2sys.Infrastructute.DTO;
using m2sys.Infrastructute.Entities;
using m2sys.Infrastructute.Services.Interface;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m2sys.Infrastructute.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IApiUnitOfWork _apiUnitOfWork;
        public EmployeeService(IApiUnitOfWork apiUnitOfWork)
        {
            _apiUnitOfWork = apiUnitOfWork;
        }

        public IEnumerable<EmployeeDTO> GetEmployeesByPagination(int index, int pageSize)
        {
            var data = _apiUnitOfWork.EmployeeRepository.GetByPigination(index, pageSize);

            if (data == null)
            {
                // _loggingService.AddLoggingMessage("No data found in Screen Capture Table.");
                return null;
            }

            var result = data.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                DOB = x.DOB,
                JoiningDate = x.JoiningDate,
                Department = x.Department,
                Designation = x.Designation,
            });

            return result;
        }

        public IEnumerable <EmployeeDTO> GetEmployees()
        {
            var data =  _apiUnitOfWork.EmployeeRepository.GetAll();
            if (data == null)
            {
               // _loggingService.AddLoggingMessage("No data found in Screen Capture Table.");
                return null;
            }

            var result = data.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                DOB = x.DOB,
                JoiningDate = x.JoiningDate,
                Department = x.Department, 
                Designation = x.Designation,
            });

            return result;
        }

        public async Task CreateEmployee(EmployeeDTO employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                throw new Exception($"Employee First Name is empty");

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Designation = employee.Designation,
                Department = employee.Department,
                JoiningDate = employee.JoiningDate,
                DOB = employee.DOB,
            };

            _apiUnitOfWork.EmployeeRepository.Add(newEmployee);
            await _apiUnitOfWork.SaveChangesAsync();
        }

        public EmployeeDTO GetEmployeeById(Guid id)
        {
            var data = _apiUnitOfWork.EmployeeRepository.GetById(id);

            if (data == null)
            {
               // _loggingService.AddLoggingMessage($"No data exist in Active Window Database with the id: {id}");
                return null;
            }

            return new EmployeeDTO()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                MiddleName = data.MiddleName, 
                LastName = data.LastName,
                Designation = data.Designation,
                Department = data.Department
            };
        }

        public bool DeleteEmployeeRecord(Guid id)
        {
            var data = _apiUnitOfWork.EmployeeRepository.GetById(id);

            if (data == null)
            {
                //_loggingService.AddLoggingMessage($"No data exist in Active Window Database with the Id: {id}");
                return false;
            }

            _apiUnitOfWork.EmployeeRepository.Remove(data);
            _apiUnitOfWork.SaveChanges();
            return true;
        }

        public async Task UpdateEmployee(EmployeeDTO employee)
        {
            var employeeUpdate = _apiUnitOfWork.EmployeeRepository.GetById(employee.Id);
            if (employeeUpdate == null)
                throw new Exception($"No Employee has found for update with Id: {employee.Id}");


            employeeUpdate.FirstName = employee.FirstName;
            employeeUpdate.MiddleName = employee.MiddleName;
            employeeUpdate.LastName = employee.LastName;
            employeeUpdate.DOB = employee.DOB;
            employeeUpdate.Designation = employee.Designation;
            employeeUpdate.Department = employee.Department;
            employeeUpdate.JoiningDate = employee.JoiningDate;

            _apiUnitOfWork.EmployeeRepository.Edit(employeeUpdate);
            await _apiUnitOfWork.SaveChangesAsync();
        }

    }
}

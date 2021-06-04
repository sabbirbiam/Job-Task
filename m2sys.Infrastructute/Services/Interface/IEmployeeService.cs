using m2sys.Infrastructute.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Services.Interface
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();

        //void AddEmployee(Employee employee); 
       

    }
}

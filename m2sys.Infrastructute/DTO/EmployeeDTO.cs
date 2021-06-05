using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Designation { get; set; }
        public int Department { get; set; }
    }
}

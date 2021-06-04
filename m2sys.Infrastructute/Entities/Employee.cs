using m2sys.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Entities
{
    public class Employee: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Designation { get; set; }
        public int Department { get; set; }
        public IList<Leave> Leaves { get; set; }

    }
}

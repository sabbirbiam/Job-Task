using m2sys.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Entities
{
    public class Leave: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int LeaveType { get; set; }
        public string Description { get; set; }
        public DateTime StrarDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee employee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.DTO
{
    public class LeaveDTO
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int LeaveType { get; set; }
        public string Description { get; set; }
        public DateTime StrarDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

using m2sys.Infrastructute.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Contexts
{
    public interface IApiContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Leave> Leaves { get; set; }
    }
}

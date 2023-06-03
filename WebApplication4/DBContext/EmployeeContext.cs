using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.DBContext
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
      
        }
        public DbSet<Employee> Employees { get; set; }

     

    }

}


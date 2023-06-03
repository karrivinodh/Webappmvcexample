using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.DBContext
{
    public class DepartmentDBContext : DbContext
    {
        public DepartmentDBContext(DbContextOptions<DepartmentDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

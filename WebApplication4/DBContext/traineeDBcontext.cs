using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.DBContext
{
    public class traineeContext:DbContext
    {
        public traineeContext(DbContextOptions<traineeContext> options) : base(options)
        {

        }
        public DbSet<Trainee> trainees { get; set; }
    }
}

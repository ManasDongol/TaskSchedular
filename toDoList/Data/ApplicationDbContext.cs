using Microsoft.EntityFrameworkCore;
using toDoList.Models;

namespace toDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor used by EF and your application
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your DbSet for to-do tasks
        public DbSet<toDoTasks> Tasks { get; set; }
    }
}
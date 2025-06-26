
using Microsoft.EntityFrameworkCore;
using Task_Management.Models;
namespace Task_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks { get; set; } 
    
    }
}

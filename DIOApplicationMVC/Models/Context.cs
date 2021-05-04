using Microsoft.EntityFrameworkCore;

namespace DIOApplicationMVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3B14NSU\SQLEXPRESS;Database=Appmvc;Integrated Security=True");
        }
    }
}
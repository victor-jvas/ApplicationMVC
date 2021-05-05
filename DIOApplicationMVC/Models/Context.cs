using Microsoft.EntityFrameworkCore;

namespace DIOApplicationMVC.Models
{
    public class Context : DbContext
    {
        virtual public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3B14NSU\SQLEXPRESS;Database=Appmvc;Integrated Security=True");
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
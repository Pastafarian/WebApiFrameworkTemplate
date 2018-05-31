using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Act> Acts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Test;Database=Test;Trusted Connection=True;");
        }
    }
}
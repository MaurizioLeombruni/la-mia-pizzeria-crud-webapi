using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

namespace WebApplicationTest.Database
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source = localhost; Database = PizzeriaV1; " + "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

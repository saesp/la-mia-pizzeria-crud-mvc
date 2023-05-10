using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace la_mia_pizzeria_static.Models
{
    //comunicare a .NET la configurazione del nostro DB e delle classi da usare
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzas;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
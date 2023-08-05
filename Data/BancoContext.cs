using Microsoft.EntityFrameworkCore;
using Pizzaria.Models;
namespace Pizzaria.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 

        }
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}

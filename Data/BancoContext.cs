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
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<PurchaseListModel> Purchases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartModel>()
                .HasOne(c => c.User)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.IdUser)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<PurchaseListModel>()
                .HasOne(c => c.Cart)
                .WithMany(c => c.Purchases)
                .HasForeignKey(c => c.IdCart)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<PurchaseListModel>()
                .HasOne(c => c.Pizza)
                .WithMany(c => c.Purchases)
                .HasForeignKey(c => c.IdPizza)
                .HasPrincipalKey(c => c.Id);
        }

    }
}

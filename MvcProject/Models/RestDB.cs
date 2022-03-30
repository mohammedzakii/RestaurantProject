using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcProject.ViewModel;

namespace MvcProject.Models
{
    public class RestDB : IdentityDbContext
    {
        public RestDB() { 

        }
        public RestDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
       
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
       
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Category> Categories { get; set; }     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RestaurantProjectFinal;Integrated Security=True ");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemOrder>().HasKey(table => new {
                table.Order_Id,
                table.Item_Id
            });

          
            base.OnModelCreating(builder);
        }

        public DbSet<MvcProject.ViewModel.RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<MvcProject.ViewModel.LoginViewModel> LoginViewModel { get; set; }

        




    }
}

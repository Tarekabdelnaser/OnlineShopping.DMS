using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DMS.Models;
using OnlineShopping.DMS.Models.ViewModels;

namespace OnlineShopping.DMS.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {



        }



        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrdersDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }

        public DbSet<RoleViewModel> RoleViewModel { get; set; }
        public DbSet<RegisterAccountViewModel> RegisterAccountViewModel { get; set; }

    }
}

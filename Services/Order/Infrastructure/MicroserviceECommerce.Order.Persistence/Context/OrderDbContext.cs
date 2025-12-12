using MicroserviceECommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Order.Persistence.Context;

public class OrderDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1435;Database=ECommerceOrderDb;User Id=Sa;Password=Sa1234.!aA;Encrypt=false");
    }


    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
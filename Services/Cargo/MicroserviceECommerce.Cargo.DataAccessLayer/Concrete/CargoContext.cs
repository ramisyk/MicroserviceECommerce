using MicroserviceECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Cargo.DataAccessLayer.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1437;Database=ECommerceCargoDb;User Id=Sa;Password=Sa1234.!aA;Encrypt=false");
    }

    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
}
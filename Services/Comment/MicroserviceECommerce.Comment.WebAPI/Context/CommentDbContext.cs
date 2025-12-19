using MicroserviceECommerce.Comment.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Comment.WebAPI.Context;

public class CommentDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1438;initial Catalog=ECommerceCommentDb;User=Sa;Password=Sa1234.!aA;Encrypt=false");
    }
    public DbSet<UserComment> UserComments { get; set; }
}
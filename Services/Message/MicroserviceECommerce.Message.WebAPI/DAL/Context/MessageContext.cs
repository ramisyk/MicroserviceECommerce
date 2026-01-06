using MicroserviceECommerce.Message.WebAPI.DAL.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Message.WebAPI.DAL.Context;

public class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {

    }
    public DbSet<UserMessage> UserMessages { get; set; }
}
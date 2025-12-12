using System.Linq.Expressions;
using MicroserviceECommerce.Order.Application.Interfaces;
using MicroserviceECommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceECommerce.Order.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrderDbContext _context;

    public Repository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
         _context.Set<T>().Update(entity);
         await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(filter);
    }
}
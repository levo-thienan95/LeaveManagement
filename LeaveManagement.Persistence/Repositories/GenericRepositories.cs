using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using DbContext = LeaveManagement.Persistence.DatabaseContext.DbContext;

namespace LeaveManagement.Persistence.Repositories;

public class GenericRepositories<T> : IGenericRepository<T> where T : BaseEntity
{ 
    protected readonly DbContext _context;
    public GenericRepositories(DbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await EntityFrameworkQueryableExtensions.ToListAsync(_context.Set<T>().AsNoTracking());
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return _context.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        return _context.SaveChangesAsync();
    }
}
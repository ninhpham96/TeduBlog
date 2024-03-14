using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeduBlog.Core.SeedWorks;

namespace TeduBlog.Data.SeedWorks;

public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
{
    protected readonly TeduBlogContext _context;
    private readonly DbSet<T> _dbSet;
    public RepositoryBase(TeduBlogContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public void Add(T entity)
    {
        _dbSet.AddAsync(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRangeAsync(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Key Id)
    {
        return await _dbSet.FindAsync(Id);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}

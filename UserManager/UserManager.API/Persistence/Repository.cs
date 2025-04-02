using Microsoft.EntityFrameworkCore;
using UserManager.API.Entities;
using UserManager.API.Interfaces;
namespace UserManager.API.Persistence;

public class Repository<T>(UserManagerDbContext dbContext) : IRepository<T> where T : BaseEntity
{
    public async Task<IEnumerable<T>> GetAll()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }
    public void Create(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        dbContext.Set<T>().Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
    }
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }
    public bool Exists(int id)
    {
        return dbContext.Set<T>().Any(x => x.Id == id);
    }
    public async Task<bool> SaveAllAsync()
    {
        return await dbContext.SaveChangesAsync() > 0;
    }
}
using UserManager.API.Entities;

namespace UserManager.API.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetByIdAsync(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    bool Exists(int id);
    Task<bool> SaveAllAsync();
}

using UserManager.API.Entities;

namespace UserManager.API.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize);
    Task<T?> GetByIdAsync(Guid id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    bool Exists(Guid id);
    Task<bool> SaveAllAsync();
}

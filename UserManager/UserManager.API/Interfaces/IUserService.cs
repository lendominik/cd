using UserManager.API.Dtos.User;

namespace UserManager.API.Interfaces;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetAll(int page, int pageSize);
    Task<GetUserDto?> Get(int id);
    public Task<int> Add(CreateUserDto user);
    public Task<bool> Update(int id, UpdateUserDto user);
    public Task<bool> Delete(int id);
}

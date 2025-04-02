using UserManager.API.Dtos.User;

namespace UserManager.API.Interfaces;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetAll(int page, int pageSize);
    Task<GetUserDto?> Get(Guid id);
    public Guid Add(CreateUserDto user);
    public async Task<bool> Update(Guid id, UpdateUserDto user);
    public async Task<bool> Delete(Guid id);
}

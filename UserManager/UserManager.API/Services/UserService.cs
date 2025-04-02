using UserManager.API.Dtos.User;
using UserManager.API.Interfaces;

namespace UserManager.API.Services;

public class UserService : IUserService
{
    public async Task<IEnumerable<GetUserDto>> GetAll(int page, int pageSize)
    {
        await Task.CompletedTask;
        return [];
    }

    public async Task<GetUserDto?> Get(int id)
    {
        await Task.CompletedTask;
        return null;
    }

    public async Task<int> Add(CreateUserDto user)
    {
        await Task.CompletedTask;
        return 0;
    }

    public async Task<bool> Update(int id, UpdateUserDto user)
    {
        await Task.CompletedTask;
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        await Task.CompletedTask;
        return true;
    }
}
using UserManager.API.Dtos.User;
using UserManager.API.Entities;
using UserManager.API.Interfaces;

namespace UserManager.API.Services;

public class UserService(IRepository<User> repository) : IUserService
{
    public async Task<IEnumerable<GetUserDto>> GetAll(int page, int pageSize)
    {
        var users = (await repository.GetAll(page, pageSize))
            .Select(u => new GetUserDto
            { 
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber
            });

        return users;
    }

    public async Task<GetUserDto?> Get(Guid id)
    {
        var user = await repository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new GetUserDto
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
        };
    }

    public Guid Add(CreateUserDto createUserDto)
    {
        var id = Guid.NewGuid();

        var user = new User
        {
            Id = id,
            Email = createUserDto.Email,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            PhoneNumber = createUserDto.PhoneNumber
        };

        repository.Create(user);
        return id;
    }

    public async Task<bool> Update(Guid id, UpdateUserDto updateUserDto)
    {
        var user = await repository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.Email = updateUserDto.Email ?? user.Email;
        user.PhoneNumber = updateUserDto.PhoneNumber ?? user.PhoneNumber;

        return await repository.SaveAllAsync();
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = await repository.GetByIdAsync(id);

        if (user == null)
            return false;

        repository.Delete(user);
        return await repository.SaveAllAsync();
    }
}
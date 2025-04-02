using Microsoft.AspNetCore.Mvc;
using UserManager.API.Dtos.User;
using UserManager.API.Interfaces;

namespace UserManager.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var users = await userService.GetAll(page, pageSize);
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(int userId)
    {
        var user = await userService.Get(userId);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdUserId = await userService.Add(user);
        return CreatedAtAction(nameof(GetById), new { userId = createdUserId });
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserDto user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await userService.Update(userId, user);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        var result = await userService.Delete(userId);
        return result ? NoContent() : NotFound();
    }
}

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
    public async Task<IActionResult> GetById(Guid userId)
    {
        var user = await userService.Get(userId);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserDto user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdUserId = userService.Add(user);
        return CreatedAtAction(nameof(GetById), new { userId = createdUserId });
    }

    [HttpPut("{userId}")]
    public IActionResult Update(Guid userId, [FromBody] UpdateUserDto user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = userService.Update(userId, user);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete(Guid userId)
    {
        var result = userService.Delete(userId);
        return result ? NoContent() : NotFound();
    }
}

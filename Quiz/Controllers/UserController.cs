using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.Services.Implementations;
using Quiz.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Quiz.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) 
    { 
        _userService = userService; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllAsync() ?? new List<User>();
        if (!users.Any())
        {
            return Ok(new List<UserDto>());
        }
        var result = users.Select(a => new UserDto
        {
            Id = a.Id,
            Name = a.Username
        });

        return Ok(result);

    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> GetById(int id) 
    { 
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
        {
            return NotFound($"User with ID {id} not found.");
        }
        var result = new UserDto
        {
            Id = user.Id,
            Name = user.Username
        };

        return Ok(result);
    }

    [HttpGet("by-username/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var user = await _userService.GetByUsernameAsync(username);
        if (user == null)
            return NotFound($"User with username {username} not found.");

        var result = new UserDto
        {
            Id = user.Id,
            Name = user.Username
        };

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var user = await _userService.RegisterAsync(dto.Username, dto.Password);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST api/user/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _userService.LoginAsync(dto.Username, dto.Password);
        if (user == null)
            return Unauthorized("Invalid username or password");

        return Ok(user);
    }
}

public class AuthDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = string.Empty;
}

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class UserUpdateDto
{
    public string? UserName { get; set; }
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string? Password { get; set; }
}


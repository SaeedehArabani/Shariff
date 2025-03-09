using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.API.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// دریافت لیست کاربران
    /// </summary>
    /// <returns>لیست کاربران</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }

    /// <summary>
    /// دریافت یک کاربر بر اساس ID
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>کاربر مورد نظر</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound("کاربر یافت نشد.");
        return Ok(user);
    }

    /// <summary>
    /// ایجاد یک کاربر جدید
    /// </summary>
    /// <param name="userDto">اطلاعات کاربر</param>
    /// <returns>کاربر ایجاد شده</returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };

        await _userRepository.AddAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    /// <summary>
    /// بروزرسانی کامل کاربر (PUT)
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="updateUserDto">اطلاعات جدید</param>
    /// <returns>نتیجه عملیات</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound("کاربر یافت نشد.");

        user.Name = updateUserDto.Name ?? user.Name;
        user.Email = updateUserDto.Email ?? user.Email;

        await _userRepository.UpdateAsync(user);
        return NoContent();
    }

    /// <summary>
    /// بروزرسانی جزئی کاربر (PATCH)
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="updateUserDto">اطلاعات جزئی برای به‌روزرسانی</param>
    /// <returns>نتیجه عملیات</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchUser([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound("کاربر یافت نشد.");

        if (updateUserDto.Name != null)
            user.Name = updateUserDto.Name;

        if (updateUserDto.Email != null)
            user.Email = updateUserDto.Email;

        await _userRepository.UpdateAsync(user);
        return NoContent();
    }

    /// <summary>
    /// حذف کاربر بر اساس ID
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>نتیجه عملیات</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound("کاربر یافت نشد.");

        await _userRepository.DeleteAsync(id);
        return NoContent();
    }
}

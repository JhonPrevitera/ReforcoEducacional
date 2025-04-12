using UserService.Application.Dtos;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services;

public class UserAppService(IUserRepository userRepository) : IUserService
{
	public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
	{
		UserBase user = dto.UserType.ToLower() switch
		{
			"student" => new Student( dto.FullName,
				dto.Email,
				dto.Password,
				dto.ParentId),
			"parent" => new Parent
			(
				dto.FullName,
				dto.Email,
				dto.Password
			),
			"admin" => new Admin
			(
				dto.FullName,
				dto.Email,
				dto.Password,
				"default"
			),
			_ => throw new ArgumentException("Invalid user type")
		};

		await userRepository.CreateUsers(user);

		return new UserDto
		{
			FullName = user.FullName,
			Email = user.Email
		};
	}
}
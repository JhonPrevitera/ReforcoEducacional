using UserService.Application.Dtos;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services;

public class UserAppService(IUserRepository userRepository) : IUserService
{
	
	
	public async Task<UserDto> CreateParentWithChildrenAsync(CreateParentRequest dto)
	{
		var parent = new Parent(dto.FullName, dto.Email, dto.Password);

		foreach (var child in dto.Children)
		{
			var student = new Student(child.FullName, child.Email, child.Password);
			parent.AddChild(student);
		}

		await userRepository.CreateUsers(parent);

		return new UserDto
		{
			FullName = parent.FullName,
			Email = parent.Email
		};
	}

}
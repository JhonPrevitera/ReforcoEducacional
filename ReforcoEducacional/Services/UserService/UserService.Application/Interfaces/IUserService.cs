using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IUserService
{
	Task<UserDto> CreateUserAsync(CreateUserDto userDto);
}
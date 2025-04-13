using UserService.Application.Dtos;

namespace UserService.Application.Interfaces;

public interface IUserService
{
	Task<UserDto> CreateParentWithChildrenAsync(CreateParentRequest dto);
}
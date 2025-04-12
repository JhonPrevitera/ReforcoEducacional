namespace UserService.Domain.Interfaces;

public interface IUserRepository
{
	Task<string> CreateUsers(UserBase user);
}
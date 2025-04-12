using UserService.Domain.Interfaces;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly UserServiceDbContext _context;
	
	public async Task<string> CreateUsers(UserBase user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
		string userFullName = user.FullName;
		return $"O usuario {userFullName} foi criado com sucesso!";
	}
}
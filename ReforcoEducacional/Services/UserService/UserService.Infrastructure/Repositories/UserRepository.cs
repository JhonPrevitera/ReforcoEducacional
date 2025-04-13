using UserService.Domain.Interfaces;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	public Task<string> CreateUsers(UserBase user)
	{
		_context.Users.Add(user); // Exemplo de uso do DbContext
		_context.SaveChanges();
		return Task.FromResult(user.FullName);
	}


	private readonly UserServiceDbContext _context;

	public UserRepository(UserServiceDbContext context) 
	{
		_context = context ?? throw new ArgumentNullException(nameof(context)); // Verifique se o _context está sendo injetado corretamente
	}
}

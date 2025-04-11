using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data;

public class UserServiceDbContext(IConfiguration configuration, DbContextOptions<UserServiceDbContext> options)
	: DbContext(options)
{
	protected readonly IConfiguration _configuration = configuration;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
	}
	public DbSet<User> Users { get; set; }
}
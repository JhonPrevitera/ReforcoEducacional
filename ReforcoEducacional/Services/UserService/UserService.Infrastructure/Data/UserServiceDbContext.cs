using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data;

public class UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : DbContext(options)
{

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserBase>().ToTable("Users");
		modelBuilder.Entity<UserBase>()
			.HasDiscriminator<string>("UserType")
			.HasValue<Student>("Student")
			.HasValue<Parent>("Parent")
			.HasValue<Admin>("Admin");

		modelBuilder.Entity<Parent>()
			.HasMany(p => p.Children)
			.WithOne(s => s.Parent)
			.HasForeignKey(s => s.ParentId);
	}public DbSet<UserBase> Users { get; set; }
}

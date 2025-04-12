using UserService.Domain.Entities;

namespace UserService.Application.Dtos;

public class CreateUserDto
{
	public string UserType { get; set; } = "Student"; // "Parent", "Admin"
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public Guid ParentId { get; set; } // Só usado se for Student
	public Parent? Parent { get; set; }
}
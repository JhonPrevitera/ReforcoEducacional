using System;

namespace UserService.Application.Dtos
{
	public class CreateUserDto
	{
		public string UserType { get; set; } = "Student";
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public Guid ParentId { get; set; }
	}
}
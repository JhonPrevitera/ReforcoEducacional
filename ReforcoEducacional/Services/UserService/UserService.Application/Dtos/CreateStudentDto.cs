namespace UserService.Application.Dtos;

public class CreateStudentDto
{
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}
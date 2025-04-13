namespace UserService.Application.Dtos;

public class CreateParentRequest
{
	public string FullName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public List<CreateStudentDto> Children { get; set; }
}
namespace UserService.Domain.Entities;

public class Admin : UserBase
{
	public string Department { get; private set; }

	public Admin(string fullName, string email, string passwordHash, string department)
		: base(fullName, email, passwordHash)
	{
		Department = department;
	}
}
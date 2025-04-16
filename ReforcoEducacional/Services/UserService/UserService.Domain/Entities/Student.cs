namespace UserService.Domain.Entities;


public class Student : UserBase
{
	public Guid ParentId { get; private set; }
	public Parent Parent { get; private set; }

	public Student(string fullName, string email, string passwordHash)
		: base(fullName, email, passwordHash){}
}

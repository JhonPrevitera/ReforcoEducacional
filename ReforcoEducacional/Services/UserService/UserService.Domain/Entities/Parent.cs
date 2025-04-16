namespace UserService.Domain.Entities;

public class Parent : UserBase
{
	public ICollection<Student> Children { get; private set; }

	public Parent(string fullName, string email, string passwordHash)
		: base(fullName, email, passwordHash)
	{
		Children = new List<Student>();
	}
	public void AddChild(Student child)
	{
		Children.Add(child);
	}
}
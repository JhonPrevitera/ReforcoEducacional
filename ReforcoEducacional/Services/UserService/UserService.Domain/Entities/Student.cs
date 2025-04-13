namespace UserService.Domain.Entities;


public class Student : UserBase
{
	public Guid ParentId { get; private set; }

	// Navegação - NÃO colocar no construtor
	public Parent Parent { get; private set; }

	// Construtor usado pela aplicação (sem propriedade de navegação)
	public Student(string fullName, string email, string passwordHash)
		: base(fullName, email, passwordHash){}
}

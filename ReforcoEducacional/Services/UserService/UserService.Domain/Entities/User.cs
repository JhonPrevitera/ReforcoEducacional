using System.Globalization;

namespace UserService.Domain.Entities;

public class User
{
	public Guid Id { get; private set; }
	public string FullName { get; private set; }
	public string Email { get; private set; }  // Valor encapsulado em um Value Object
	public string Password { get; private set; }  // Outro Value Object para senha

	// Construtor que garante a integridade dos dados
	public User(string fullName, string email, string password)
	{
		Id = Guid.NewGuid();
		FullName = fullName;
		Email = email;
		Password = password;
	}
}
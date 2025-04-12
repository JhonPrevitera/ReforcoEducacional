public abstract class UserBase
{
	public Guid Id { get; protected set; }
	public string FullName { get; protected set; }
	public string Email { get; protected set; }
	public string PasswordHash { get; protected set; }

	public UserBase(string fullName, string email, string passwordHash)
	{
		Id = Guid.NewGuid();
		FullName = fullName;
		Email = email;
		PasswordHash = passwordHash;
	}
}
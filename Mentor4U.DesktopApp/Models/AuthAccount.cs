namespace Mentor4U.DesktopApp.Models;

public enum Role { Admin, Mentor, Student }

public class AuthAccount
{
    public required string Login { get; init; }
    public required string LastName { get; init; }
    public required string FirstName { get; init; }
    public string FullName => $"{FirstName} {LastName}";
    public required string Email { get; init; }
    public required Role Role { get; init; }
}
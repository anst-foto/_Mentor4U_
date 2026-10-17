namespace Mentor4U.CoreLib.Models;

public enum Role { Admin, Mentor, Student }

public class Account : BaseAccount
{
    public required string Login { get; init; }
    public required string Password { get; init; }
    
    public required Role Role { get; init; }
    
    public User User { get; init; }
}
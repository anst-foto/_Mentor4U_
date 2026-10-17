using System;

namespace Mentor4U.DesktopApp.Models;

public class Account
{
    public required string Login { get; init; }
    public required string Password { get; init; }
}
using System;

namespace Mentor4U.CoreLib.Models;

public abstract class BaseAccount
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
}
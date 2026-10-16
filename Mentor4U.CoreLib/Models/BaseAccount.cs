using System;

namespace Mentor4U.CoreLib.Interfaces;

public abstract class BaseAccount
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
}
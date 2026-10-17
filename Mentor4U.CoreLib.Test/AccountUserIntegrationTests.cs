using System;
using System.Threading.Tasks;

using Mentor4U.CoreLib.Models;

using Microsoft.EntityFrameworkCore;

using Xunit;

namespace Mentor4U.CoreLib.Test;

public class AccountUserIntegrationTests : IClassFixture<PostgresFixture>
{
    private readonly PostgresFixture _fixture;

    public AccountUserIntegrationTests(PostgresFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Should_Persist_Account_With_User_And_Read_Back()
    {
        // Arrange
        await using var context = _fixture.CreateContext();

        var account = new Account { Login = "mentor_ivan", Password = "hashed_password", Role = Role.Mentor };

        var user = new User { LastName = "Иванов", FirstName = "Иван", Email = "ivan@example.com", Account = account };

        // Act
        context.Accounts.Add(account);
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Assert
        await using var readContext = _fixture.CreateContext();

        var persistedAccount = await readContext.Accounts
            .Include(a => a.User)
            .SingleAsync(a => a.Login == "mentor_ivan");

        Assert.NotNull(persistedAccount.User);
        Assert.Equal("Иванов", persistedAccount.User.LastName);
        Assert.Equal("ivan@example.com", persistedAccount.User.Email);
        Assert.Equal(Role.Mentor, persistedAccount.Role);
    }

    [Fact]
    public async Task Should_Enforce_One_To_One_Relationship()//BUG
    {
        // Arrange
        await using var context = _fixture.CreateContext();

        var account = new Account { Login = "student_petrov", Password = "hashed_password", Role = Role.Student };

        var user = new User
        {
            LastName = "Петров", FirstName = "Пётр", Email = "petrov@example.com", Account = account
        };

        context.Accounts.Add(account);
        context.Users.Add(user);
        await context.SaveChangesAsync();

        // Act: пытаемся привязать второго пользователя к тому же аккаунту
        var secondUser = new User
        {
            LastName = "Сидоров", FirstName = "Сидор", Email = "sidorov@example.com", AccountId = account.Id
        };

        context.Users.Add(secondUser);

        // Assert
        await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
    }

    [Fact]
    public async Task Should_Generate_Guid_V7_For_Id()
    {
        // Arrange
        await using var context = _fixture.CreateContext();

        var account = new Account { Login = "admin_root", Password = "hashed_password", Role = Role.Admin };

        // Act
        context.Accounts.Add(account);
        await context.SaveChangesAsync();

        // Assert
        Assert.NotEqual(Guid.Empty, account.Id);
        // Guid.CreateVersion7() генерирует UUID версии 7 — проверим старший ниббл версии.
        Assert.Equal(7, account.Id.Version);
    }
}
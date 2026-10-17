using TicketSales.Data;
using TicketSales.Models;

namespace TicketSales.Services;

public class UserService
{
    private readonly CinemaContext context;

    public UserService(CinemaContext context)
    {
        this.context = context;
    }

    public User? Authenticate(
        string username,
        string password)
    {
        var user =
            context.Users
                .FirstOrDefault(x =>
                    x.Username == username);

        if (user is null)
            return null;

        return PasswordService.Verify(
            password,
            user.PasswordHash)
                ? user
                : null;
    }

    public void CreateUser(
        string username,
        string password,
        string fullName)
    {
        var user = new User
        {
            Username = username,
            PasswordHash =
                PasswordService.Hash(password),
            FullName = fullName
        };

        context.Users.Add(user);

        context.SaveChanges();
    }
}
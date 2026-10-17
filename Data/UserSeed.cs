using TicketSales.Models;
using TicketSales.Services;

namespace TicketSales.Data;

public static class UserSeed
{
    public static void Initialize(
        IServiceProvider services)
    {
        var context =
            services.GetRequiredService<CinemaContext>();

        if (context.Users.Any())
            return;

        context.Users.Add(
            new User
            {
                Username = "admin",
                FullName = "System Administrator",
                PasswordHash =
                    PasswordService.Hash(
                        "Admin123!")
            });

        context.SaveChanges();
    }
}
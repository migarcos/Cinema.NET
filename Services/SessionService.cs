using TicketSales.Models;

namespace TicketSales.Services;

public class SessionService
{
    public User? CurrentUser { get; private set; }

    public bool IsAuthenticated =>
        CurrentUser is not null;

    public void Login(User user)
    {
        CurrentUser = user;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}
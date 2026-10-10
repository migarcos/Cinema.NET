using TicketSales.Models;

namespace TicketSales.Services;

public class ShowingService
{
    private readonly List<Showing> showings = [];

    public IReadOnlyList<Showing> GetShowings()
    {
        return showings;
    }

    public void AddShowing(Showing showing)
    {
        showings.Add(showing);
    }
}
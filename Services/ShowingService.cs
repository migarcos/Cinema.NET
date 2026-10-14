using Microsoft.EntityFrameworkCore;
using TicketSales.Data;
using TicketSales.Models;

namespace TicketSales.Services;

public class ShowingService
{
    private readonly CinemaContext context;

    public ShowingService(CinemaContext context)
    {
        this.context = context;
    }
    public IReadOnlyList<Showing> GetShowings()
    {
        return context.Showings
            .Include(s => s.Movie)
            .Include(s => s.Auditorium)
            .OrderBy(s => s.Date)
            .ToList();
    }

    public void AddShowing(Showing showing)
    {
        context.Showings.Add(showing);
        context.SaveChanges();
    }

    public Showing? GetShowing(Guid id)
    {
        return context.Showings
            .FirstOrDefault(s => s.Id == id);
    }

    public void UpdateShowing(Showing showing)
    {
        var existingShowing =
            context.Showings.FirstOrDefault(
                s => s.Id == showing.Id);

        if (existingShowing is null)
            return;

        existingShowing.MovieId = showing.MovieId;
        existingShowing.AuditoriumId = showing.AuditoriumId;
        existingShowing.Date = showing.Date;
        existingShowing.Time = showing.Time;
        existingShowing.TicketPrice = showing.TicketPrice;

        context.SaveChanges();
    }

    public void DeleteShowing(Guid id)
    {
        var showing =
            context.Showings.FirstOrDefault(
                s => s.Id == id);

        if (showing is null)
            return;

        context.Showings.Remove(showing);

        context.SaveChanges();
    }
}
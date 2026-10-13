using Microsoft.EntityFrameworkCore;
using TicketSales.Data;
using TicketSales.Models;

namespace TicketSales.Services;
public class MovieService
{
    private readonly CinemaContext context;

    public MovieService(CinemaContext context)
    {
        this.context = context;
    }

    public IReadOnlyList<Movie> GetMovies()
    {
        return context.Movies
            .OrderBy(m => m.Title)
            .ToList();
    }

    public void AddMovie(Movie movie)
    {
        context.Movies.Add(movie);

        context.SaveChanges();
    }
}
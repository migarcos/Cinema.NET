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

    public Movie? GetMovie(Guid id)
    {
        return context.Movies
            .FirstOrDefault(m => m.Id == id);
    }

    public void UpdateMovie(Movie movie)
    {
        var existingMovie =
            context.Movies.FirstOrDefault(
                m => m.Id == movie.Id);

        if (existingMovie is null)
            return;

        existingMovie.Title = movie.Title;
        existingMovie.Genre = movie.Genre;
        existingMovie.Rating = movie.Rating;
        existingMovie.DurationMns = movie.DurationMns;
        existingMovie.Description = movie.Description;

        context.SaveChanges();
    }

    public void DeleteMovie(Guid id)
    {
        var movie = context.Movies
            .FirstOrDefault(m => m.Id == id);

        if (movie is null)
            return;

        context.Movies.Remove(movie);

        context.SaveChanges();
    }
}
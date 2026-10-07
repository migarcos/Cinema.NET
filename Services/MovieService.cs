using TicketSales.Models;
namespace TicketSales.Services;
public class MovieService
{
    private readonly List<Movie> movies = [];   // outside classes can't access movies directly only using GetMovies
    public IReadOnlyList<Movie> GetMovies()     // don´t manipulate the collection directly
    {
        return movies;
    }
    public void AddMovie(Movie movie)   // The UI should use it, instead of movie.Add(movie)
    {
        movies.Add(movie);
    }
}
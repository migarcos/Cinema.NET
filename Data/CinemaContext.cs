using Microsoft.EntityFrameworkCore;
using TicketSales.Models;

namespace TicketSales.Data;

public class CinemaContext : DbContext
{
    public CinemaContext(
        DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Auditorium> Auditoriums => Set<Auditorium>();

    public DbSet<Chair> Chairs => Set<Chair>();

    public DbSet<Showing> Showings => Set<Showing>();
}
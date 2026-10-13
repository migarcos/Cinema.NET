using Microsoft.EntityFrameworkCore;
using TicketSales.Data;
using TicketSales.Models;

namespace TicketSales.Services;

public class AuditoriumService
{
    private readonly CinemaContext context;
    public AuditoriumService(CinemaContext context)
    {
        this.context = context;
    }
    public IReadOnlyList<Auditorium> GetAuditoriums()
    {
        return context.Auditoriums
            .Include(a => a.Chairs)
            .OrderBy(a => a.Name)
            .ToList();
    }

    public void AddAuditorium(Auditorium auditorium)
    {
        GenerateChairs(auditorium);

        context.Auditoriums.Add(auditorium);

        context.SaveChanges();
    }

    public static void GenerateChairs(Auditorium auditorium)
    {
        auditorium.Chairs.Clear();
        for (var rowIndex = 0; rowIndex < auditorium.Rows; rowIndex++)
        {
            var row = ((char)('A' + rowIndex)).ToString();

            for (var chairNumber = 1;
                chairNumber <= auditorium.ChairsPerRow;
                chairNumber++)
            {
                auditorium.Chairs.Add(new Chair
                {
                    Row = row,
                    Number = chairNumber
                });
            }
        }
    }

    public Auditorium? GetAuditorium(string name)
    {
        return context.Auditoriums
            .Include(a => a.Chairs)
            .FirstOrDefault(a => a.Name == name);
    }
}
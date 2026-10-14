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

    public Auditorium? GetAuditorium(Guid Id)
    {
        return context.Auditoriums
            .Include(a => a.Chairs)
            .FirstOrDefault(a => a.Id == Id);
    }

    public void UpdateAuditorium(Auditorium auditorium)
    {
        var existingAuditorium =
            context.Auditoriums
                .Include(a => a.Chairs)
                .FirstOrDefault(a => a.Id == auditorium.Id);

        if (existingAuditorium is null)
            return;

        existingAuditorium.Name = auditorium.Name;

        context.SaveChanges();
    }

    public void DeleteAuditorium(Guid id)
    {
        var auditorium =
            context.Auditoriums
                .Include(a => a.Chairs)
                .FirstOrDefault(a => a.Id == id);

        if (auditorium is null)
            return;

        context.Auditoriums.Remove(auditorium);

        context.SaveChanges();
    }
}
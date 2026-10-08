using TicketSales.Models;
using TicketSales.Services;

namespace TicketSales.Services;

public class AuditoriumService
{
    private readonly List<Auditorium> auditoriums = [];

    public IReadOnlyList<Auditorium> GetAuditoriums()
    {
        return auditoriums;
    }

    public void AddAuditorium(Auditorium auditorium)
    {
        GenerateChairs(auditorium);
        auditoriums.Add(auditorium);
    }

    public static void GenerateChairs(Auditorium auditorium)
    {
        auditorium.Chairs.Clear();
        for (var rowIndex = 0; rowIndex < auditorium.Rows; rowIndex++)
        {
            var row = ((char)('A'+ rowIndex)).ToString();
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
}
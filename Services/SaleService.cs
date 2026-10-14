using Microsoft.EntityFrameworkCore;
using TicketSales.Data;
using TicketSales.Models;

namespace TicketSales.Services;

public class SaleService
{
    private readonly CinemaContext context;

    public SaleService(CinemaContext context)
    {
        this.context = context;
    }

    public void CreateSale(
        Guid showingId,
        List<SelectedChair> selectedChairs,
        decimal total)
    {
        var sale = new Sale
        {
            ShowingId = showingId,
            Total = total
        };

        foreach (var chair in selectedChairs)
        {
            sale.Chairs.Add(
                new SoldChair
                {
                    Row = chair.Row,
                    Number = chair.Number
                });
        }

        context.Sales.Add(sale);

        context.SaveChanges();
    }

    public IReadOnlyList<Sale> GetSales()
    {
        return context.Sales
            .Include(x => x.Chairs)
            .OrderByDescending(x => x.SoldAt)
            .ToList();
    }
}
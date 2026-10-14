namespace TicketSales.Models;

public class SoldChair
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Row { get; set; } = string.Empty;

    public int Number { get; set; }

    public Guid SaleId { get; set; }
}
namespace TicketSales.Models;

public class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShowingId { get; set; }
    public decimal Total { get; set; }
    public DateTime SoldAt { get; set; } = DateTime.Now;
    public List<SoldChair> Chairs { get; set; } = [];
}
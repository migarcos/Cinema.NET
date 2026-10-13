namespace TicketSales.Models;

public class Chair
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Row { get; set; } = string.Empty;
    public int  Number { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid AuditoriumId { get; set; }
}
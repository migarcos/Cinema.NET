namespace TicketSales.Models;

public class Chair
{
    public string Row { get; set; } = string.Empty;
    public int  Number { get; set; }
    public bool IsActive { get; set; } = true;
}
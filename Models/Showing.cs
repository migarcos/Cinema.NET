using System.ComponentModel.DataAnnotations;
namespace TicketSales.Models;
public class Showing
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage ="Movie is required.")]
    public string MovieTitle {get; set; } = string.Empty;

    [Required(ErrorMessage ="Auditorium is required.")]
    public string AuditoriumName {get; set; } = string.Empty;

    [Required]
    public DateOnly Date {get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Required]
    // public TimeOnly Time {get; set; } = new(19, 0);
    public string Time {get; set; } ="19:00";

    [Range(0.01, 99.99, ErrorMessage ="Ticket price must be greater than zero.")]
    public decimal TicketPrice {get; set; }
}
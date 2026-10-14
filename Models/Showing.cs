using System.ComponentModel.DataAnnotations;
namespace TicketSales.Models;
public class Showing
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // [Required(ErrorMessage ="Movie is required.")]
    // public string MovieTitle {get; set; } = string.Empty;
    [Required]
    public Guid MovieId { get; set; }

    // [Required(ErrorMessage ="Auditorium is required.")]
    // public string AuditoriumName {get; set; } = string.Empty;
    [Required]
    public Guid AuditoriumId { get; set; }

    public Movie? Movie { get; set; }

    public Auditorium? Auditorium { get; set; }

    [Required]
    public DateOnly Date {get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Required (ErrorMessage = "Time is required.")]
    // public TimeOnly Time {get; set; } = new(19, 0);
    public string Time {get; set; } = string.Empty;

    [Range(0.01, 99.99, ErrorMessage ="Ticket price must be greater than zero or lower than 100.")]
    public decimal TicketPrice {get; set; }
}
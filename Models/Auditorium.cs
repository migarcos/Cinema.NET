using System.ComponentModel.DataAnnotations;
namespace TicketSales.Models;

public class Auditorium
{
    [Required(ErrorMessage = "Name is reuired.")]
    [StringLength(100, ErrorMessage = "Auditorium name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;
    // from A .. Z (26 letters)
    [Range(1, 26, ErrorMessage = "Row will be 1 to 26.")]
    public int Rows { get; set; }

    [Range(1, 50, ErrorMessage = "Chairs per row must be 1 to 50.")]
    public int ChairsPerRow { get; set; }

    public List<Chair> Chairs { get; set; } = [];

}
// MS recommends Data Annotations on the model together with 
// DataAnnotationsValidator in an EditForm for straightforward Blazor form validation
using System.ComponentModel.DataAnnotations;
using TicketSales.Components.Pages;

namespace TicketSales.Models;

public class Movie
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(150, ErrorMessage = "Max Lenght 150 chars")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rating is required")]
    [StringLength(6, ErrorMessage = "Rating max chars 6")]
    public string Rating { get; set; } = string.Empty;

    [Range(1, 240, ErrorMessage = "Duration will be between 1 to 240")]
    public int DurationMns { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
    public string Genre { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string Description { get; set; } = string.Empty;
}
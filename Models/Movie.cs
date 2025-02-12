using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Movie
{
    [Key] // Primary key
    public int MovieId { get; set; }
    
    [Required] // Makes it so that it must be entered
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; } // Use a dropdown for this
    
    public bool? Edited { get; set; } // ? Makes it so it can be null
    public string? LentTo { get; set; }
    
    [StringLength(25)] // Limit of 25 characters
    public string? Notes { get; set; }
}
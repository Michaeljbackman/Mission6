using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    public string? Director { get; set; }  // Allow NULLs to match DB

    public string? Rating { get; set; }  // Allow NULLs to match DB

    public bool? Edited { get; set; }

    public string? LentTo { get; set; }  // Allow NULLs to match DB

    public int CopiedToPlex { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }  // Allow NULLs to match DB
}

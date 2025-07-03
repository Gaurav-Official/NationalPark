using NationlParkAPI_2.Models.DTOs;
using System.ComponentModel.DataAnnotations;

public class TrailDto
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Distance { get; set; }

    [Required]
    public double Elevation { get; set; }

    public DateTime DateCreated { get; set; }

    public DifficultyType Difficulty { get; set; }

    public int NationalParkId { get; set; } // ✅ Correct foreign key name

    public NationalParkDto NationalPark { get; set; } // ✅ Navigation property

    
}
public enum DifficultyType
{
    Easy,
    Moderate,
    Difficult
}

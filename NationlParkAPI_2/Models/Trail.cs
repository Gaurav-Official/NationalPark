using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationlParkAPI_2.Models
{
    public class Trail
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Distance { get; set; } // ✅ Use double

        [Required]
        public double Elevation { get; set; } // ✅ Use double

        public DateTime DateCreated { get; set; }

        public DifficultyType Difficulty { get; set; }

        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")] // ✅ Correct spelling
        public NationalPark NationalPark { get; set; }

        public enum DifficultyType
        {
            Easy,
            Moderate,
            Difficult
        }
    }
}

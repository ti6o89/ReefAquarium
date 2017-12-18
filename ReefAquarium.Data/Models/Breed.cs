namespace ReefAquarium.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Breed
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BreedNameMinLength)]
        [MaxLength(BreenNameMaxLength)]
        public string Name { get; set; }

        public int MinTankSize { get; set; }

        public bool ReefCompatible { get; set; }

        public CareLevel CareLevel { get; set; }

        public Temperament Temperament { get; set; }

        public int MaxSize { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Diet { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<Fish> Fish { get; set; } = new List<Fish>();
    }
}

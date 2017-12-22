namespace ReefAquarium.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Fish
    {
        public int Id { get; set; }

        [Range(MinFishQuantity, MaxFishQuantity)]
        public int Quantity { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        public int AquariumId { get; set; }

        public Aquarium Aquarium { get; set; }
    }
}

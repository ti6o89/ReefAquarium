namespace ReefAquarium.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Fish
    {
        public int Id { get; set; }

        [Range(1, 300)]
        public int Quantity { get; set; }

        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        public int AquariumId { get; set; }

        public Aquarium Aquarium { get; set; }
    }
}

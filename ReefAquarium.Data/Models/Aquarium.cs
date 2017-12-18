namespace ReefAquarium.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Aquarium
    {
        public int Id { get; set; }

        [Required]
        [MinLength(AquariumTitleMinLength)]
        [MaxLength(AquariumTitleMaxLength)]
        public string Title { get; set; }

        //in cm
        public int Length { get; set; }

        //in cm
        public int Width { get; set; }

        //in cm
        public int Height { get; set; }

        public int Volume => (this.Width * this.Height * this.Length) / 1000;

        [Required]
        [MaxLength(AquariumDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public List<Fish> Fish { get; set; } = new List<Fish>();
    }
}

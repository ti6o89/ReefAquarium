namespace ReefAquarium.Web.Models.Aquariums
{
    using ReefAquarium.Data;
    using System.ComponentModel.DataAnnotations;

    public class AquariumFormModel
    {
        [Required]
        [MinLength(DataConstants.AquariumTitleMinLength)]
        [MaxLength(DataConstants.AquariumTitleMaxLength)]
        public string Title { get; set; }

        //in cm
        public int Length { get; set; }

        //in cm
        public int Width { get; set; }

        //in cm
        public int Height { get; set; }

        [Required]
        [MaxLength(DataConstants.AquariumDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}

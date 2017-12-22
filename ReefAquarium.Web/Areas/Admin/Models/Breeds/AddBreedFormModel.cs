namespace ReefAquarium.Web.Areas.Admin.Models.Breeds
{
    using Data;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AddBreedFormModel
    {
        [Required]
        [MinLength(DataConstants.BreedNameMinLength)]
        [MaxLength(DataConstants.BreenNameMaxLength)]
        public string Name { get; set; }

        [Display(Name = "Min Tank Size")]
        public int MinTankSize { get; set; }

        [Display(Name = "Reef Compatible")]
        public bool ReefCompatible { get; set; }

        [Display(Name = "Care Level")]
        public CareLevel CareLevel { get; set; }

        public Temperament Temperament { get; set; }

        [Display(Name = "Max Size")]
        public int MaxSize { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Diet { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
    }
}


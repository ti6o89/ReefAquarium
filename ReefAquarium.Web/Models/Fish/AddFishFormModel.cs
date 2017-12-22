namespace ReefAquarium.Web.Models.Fish
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddFishFormModel
    {
        [Range(1, 300)]
        public int Quantity { get; set; }

        [Display(Name = "Breed")]
        public int BreedId { get; set; }

        public IEnumerable<SelectListItem> Breeds { get; set; }

        public int AquariumId { get; set; }
    }
}

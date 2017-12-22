namespace ReefAquarium.Services.Models.Breeds
{
    using Common.Mapping;
    using Data.Models;


    public class BreedListingServiceModel : IMapFrom<Breed>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}

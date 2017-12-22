namespace ReefAquarium.Services.Models.Aquariums
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class AquariumListingServiceModel : IMapFrom<Aquarium>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Owner { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Aquarium, AquariumListingServiceModel>()
                .ForMember(a => a.Owner, cfg => cfg.MapFrom(a => a.Owner.Name));
    }
}

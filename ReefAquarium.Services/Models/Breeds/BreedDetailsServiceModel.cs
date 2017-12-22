namespace ReefAquarium.Services.Models.Breeds
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class BreedDetailsServiceModel : IMapFrom<Breed>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name ="Min Tank Size")]
        public int MinTankSize { get; set; }

        [Display(Name = "Reef Compatible")]
        public bool ReefCompatible { get; set; }

        [Display(Name = "Care Level")]
        public string CareLevel { get; set; }

        public string Temperament { get; set; }

        [Display(Name = "Max Size")]
        public int MaxSize { get; set; }

        public string Diet { get; set; }

        public string ImageUrl { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Breed, BreedDetailsServiceModel>()
                .ForMember(b => b.CareLevel, cfg => cfg.MapFrom(b => b.CareLevel.ToString()))
                .ForMember(b => b.Temperament, cfg => cfg.MapFrom(b => b.Temperament.ToString()));
    }
}

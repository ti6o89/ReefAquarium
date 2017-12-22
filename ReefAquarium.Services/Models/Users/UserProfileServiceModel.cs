namespace ReefAquarium.Services.Models.Users
{
    using Common.Mapping;
    using Data.Models;
    using Services.Models.Aquariums;
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using System.Linq;

    public class UserProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public DateTime BrithDate { get; set; }

        public IEnumerable<AquariumListingServiceModel> Aquariums { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<User, UserProfileServiceModel>()
                .ForMember(u => u.Aquariums, cfg => cfg.MapFrom(a => a.Aquariums));
    }
}

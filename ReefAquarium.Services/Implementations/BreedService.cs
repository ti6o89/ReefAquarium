namespace ReefAquarium.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Models.Breeds;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BreedService : IBreedService
    {
        private readonly ReefAquariumDbContext db;

        public BreedService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BreedListingServiceModel>> AllAsync()
            => await this.db
                .Breeds
                .ProjectTo<BreedListingServiceModel>()
                .ToListAsync();

        public async Task<BreedDetailsServiceModel> ById(int id)
            => await this.db
                .Breeds
                .Where(b => b.Id == id)
                .ProjectTo<BreedDetailsServiceModel>()
                .FirstOrDefaultAsync();
    }
}

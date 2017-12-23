namespace ReefAquarium.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using ReefAquarium.Services.Admin.Models.Breeds;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminBreedService : IAdminBreedService
    {
        private readonly ReefAquariumDbContext db;

        public AdminBreedService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task AddBreedAsync(string name, int minTankSize, bool reefCompatible, CareLevel careLevel,
            Temperament temperament, int maxSize, string diet, string imageUrl)
        {
            var breed = new Breed
            {
                Name = name,
                MinTankSize = minTankSize,
                ReefCompatible = reefCompatible,
                CareLevel = careLevel,
                Temperament = temperament,
                MaxSize = maxSize,
                Diet = diet,
                ImageUrl = imageUrl
            };

            this.db.Add(breed);
            await this.db.SaveChangesAsync();
        }
        public async Task EditAsync(int id, string name, int minTankSize, bool reefCompatible, CareLevel careLevel,
            Temperament temperament, int maxSize, string diet, string imageUrl)
        {
            var existingBreed = await this.db
                .Breeds
                .FindAsync(id);

            if (existingBreed == null)
            {
                return;
            }

            existingBreed.Name = name;
            existingBreed.MinTankSize = minTankSize;
            existingBreed.ReefCompatible = reefCompatible;
            existingBreed.CareLevel = careLevel;
            existingBreed.Temperament = temperament;
            existingBreed.MaxSize = maxSize;
            existingBreed.Diet = diet;
            existingBreed.ImageUrl = imageUrl;

            await this.db.SaveChangesAsync();
        }

        public async Task<BreedServiceAdminModel> ById(int id)
            => await this.db
                .Breeds
                .Where(b => b.Id == id)
                .ProjectTo<BreedServiceAdminModel>()
                .FirstOrDefaultAsync();
    }
}

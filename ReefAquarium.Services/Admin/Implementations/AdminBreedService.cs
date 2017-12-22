namespace ReefAquarium.Services.Admin.Implementations
{
    using Data;
    using Data.Models;
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
    }
}

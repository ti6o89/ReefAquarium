namespace ReefAquarium.Services.Implementations
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class FishService : IFishService
    {
        private readonly ReefAquariumDbContext db;

        public FishService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(int quantity, int breedId, int aquariumId)
        {
            var existingFish = await this.db
                .Fish
                .Where(f => f.BreedId == breedId && f.AquariumId == aquariumId)
                .FirstOrDefaultAsync();

            if (existingFish != null)
            {
                existingFish.Quantity += quantity;

                await this.db.SaveChangesAsync();
            }
            else
            {
                var fish = new Fish
                {
                    Quantity = quantity,
                    BreedId = breedId,
                    AquariumId = aquariumId
                };

                this.db.Add(fish);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task PlusOne(int id)
        {
            var exsitingFish = await this.db
                .Fish
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            if (exsitingFish == null)
            {
                return;
            }

            exsitingFish.Quantity += 1;

            await this.db.SaveChangesAsync();
        }   

        public async Task SubstractOne(int id)
        {
            var exsitingFish = await this.db
                .Fish
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            if (exsitingFish == null)
            {
                return;
            }
            if (exsitingFish.Quantity <= 1)
            {
                return;
            }

            exsitingFish.Quantity -= 1;

            await this.db.SaveChangesAsync();
        }
    }
}

namespace ReefAquarium.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Models.Aquariums;
    using Services.Models.Comments;
    using Services.Models.Fish;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AquariumService : IAquariumService
    {
        private readonly ReefAquariumDbContext db;

        public AquariumService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task CerateAsync(string title, int length, int width, int height, string description, string imageUrl, string ownerId)
        {
            var aquarium = new Aquarium
            {
                Title = title,
                Length = length,
                Width = width,
                Height = height,
                Description = description,
                ImageUrl = imageUrl,
                OwnerId = ownerId
            };

            this.db.Add(aquarium);
            await this.db.SaveChangesAsync();
        }

        public async Task<AquariumDetailsServiceModel> ById(int id)
            => await this.db
                .Aquariums
                .Where(a => a.Id == id)
                .Select(a => new AquariumDetailsServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Length = a.Length,
                    Width = a.Width,
                    Height = a.Height,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Comments = a.Comments
                        .OrderByDescending(c => c.PublishDate)
                        .Select(c => new CommentServiceModel
                        {
                            Author = c.Author.Name,
                            Content = c.Content,
                            PublishDate = c.PublishDate
                        })
                        .ToList(),
                    Owner = a.Owner.Name,
                    Fish = a.Fish
                        .Select(f => new FishServiceModel
                        {
                            Id = f.Id,
                            BreedId = f.BreedId,
                            BreedName = f.Breed.Name,
                            Quantity = f.Quantity
                        })

                })
                .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string title, int length, int width, int height, string description, string imageUrl)
        {
            var existingAquarium = await this.db
                .Aquariums
                .FindAsync(id);

            if (existingAquarium == null)
            {
                return;
            }
            
            existingAquarium.Title = title;
            existingAquarium.Length = length;
            existingAquarium.Width = width;
            existingAquarium.Height = height;
            existingAquarium.Description = description;
            existingAquarium.ImageUrl = imageUrl;

            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AquariumListingServiceModel>> AllAsync()
            => await this.db
                .Aquariums
                .OrderBy(a => a.Id)
                .ProjectTo<AquariumListingServiceModel>()
                .ToListAsync();

        public async Task<bool> UserIsOwner(int aquariumId, string userId)
            => await this.db
                .Aquariums
                .AnyAsync(a => a.Id == aquariumId && a.OwnerId == userId);      
    }
}

namespace ReefAquarium.Services
{
    using Services.Models.Aquariums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAquariumService
    {
        Task CerateAsync(string title, int length, int width, int height, string description, string imageUrl, string ownerId);

        Task EditAsync(int id, string title, int length, int width, int height, string description, string imageUrl);

        Task<IEnumerable<AquariumListingServiceModel>> AllAsync();

        Task<AquariumDetailsServiceModel> ById(int id);

        Task<bool> UserIsOwner(int aquariumId, string userId);
    }
}

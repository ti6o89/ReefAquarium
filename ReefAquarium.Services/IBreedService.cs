namespace ReefAquarium.Services
{
    using Services.Models.Breeds;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBreedService
    {
        Task<IEnumerable<BreedListingServiceModel>> AllAsync();

        Task<BreedDetailsServiceModel> ById(int id);
    }
}

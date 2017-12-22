namespace ReefAquarium.Services.Admin
{
    using Data.Models;
    using Services.Admin.Models.Breeds;
    using System.Threading.Tasks;

    public interface IAdminBreedService
    {
        Task AddBreedAsync(string Name, int MinTankSize, bool ReefCompatible, CareLevel CareLevel,
            Temperament Temperament, int MaxSize, string Diet, string ImageUrl);

        Task EditAsync(int id, string name, int minTankSize, bool reefCompatible, CareLevel careLevel,
            Temperament temperament, int maxSize, string diet, string imageUrl);

        Task<BreedServiceAdminModel> ById(int id);
    }
}

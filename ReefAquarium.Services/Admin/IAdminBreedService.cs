namespace ReefAquarium.Services.Admin
{
    using Data.Models;
    using System.Threading.Tasks;

    public interface IAdminBreedService
    {
        Task AddBreedAsync(string Name, int MinTankSize, bool ReefCompatible, CareLevel CareLevel,
            Temperament Temperament, int MaxSize, string Diet, string ImageUrl);
    }
}

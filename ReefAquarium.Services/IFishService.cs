namespace ReefAquarium.Services
{
    using System.Threading.Tasks;

    public interface IFishService
    {
        Task AddAsync(int quantity, int breedId, int aquariumId);

        Task PlusOne(int id);

        Task SubstractOne(int id);
    }
}

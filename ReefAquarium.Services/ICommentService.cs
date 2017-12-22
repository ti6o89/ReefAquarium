namespace ReefAquarium.Services
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task AddAsync(string comment, string authorId, int aquariumId);

        Task DeletetAsync(int id);

        Task<bool> UserIsAquthor(string userId, int commentId);
    }
}

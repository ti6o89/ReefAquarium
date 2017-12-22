namespace ReefAquarium.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using ReefAquarium.Data;
    using ReefAquarium.Services.Models.Users;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ReefAquariumDbContext db;

        public UserService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
            => await this.db
            .Users
            .Where(u => u.Id == id)
            .ProjectTo<UserProfileServiceModel>(new { studentId = id })
            .FirstOrDefaultAsync();
    }
}

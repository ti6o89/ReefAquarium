namespace ReefAquarium.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Admin.Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly ReefAquariumDbContext db;

        public AdminUserService(ReefAquariumDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserListingServiceModel>> AllAsync()
            => await this.db
                .Users
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();
    }
}

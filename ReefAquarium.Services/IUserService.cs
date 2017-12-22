﻿namespace ReefAquarium.Services
{
    using Services.Models.Users;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string id);
    }
}

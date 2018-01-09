namespace SpinningFish.Services.Admin
{
    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}

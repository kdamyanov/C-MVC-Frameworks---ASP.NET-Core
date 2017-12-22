using System.Threading.Tasks;

namespace SpinningFish.Services.Admin
{
    using Models;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}

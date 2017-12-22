using System.Collections.Generic;
using System.Threading.Tasks;
using SpinningFish.Services.Admin.Models;

namespace SpinningFish.Services.Admin
{
    public interface IAdminBrandService
    {
        Task Create(string name,string description, byte[] image);

        Task<IEnumerable<AdminBrandListingServiceModel>> AllListindAsync();

        IEnumerable<BrandModel> All();
    }
}

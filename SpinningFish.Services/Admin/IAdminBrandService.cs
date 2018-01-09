namespace SpinningFish.Services.Admin
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminBrandService
    {
        Task Create(string name,string description, byte[] image);

        Task<IEnumerable<AdminBrandListingServiceModel>> AllListindAsync();

        IEnumerable<BrandModel> All();
    }
}

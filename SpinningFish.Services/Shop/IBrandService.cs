namespace SpinningFish.Services.Shop
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBrandService
    {
        Task<IEnumerable<BrandListingServiceModel>> AllListingAsync();

        
    }
}

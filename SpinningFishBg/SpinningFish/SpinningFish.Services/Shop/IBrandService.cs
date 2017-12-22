using System.Collections.Generic;
using System.Threading.Tasks;
using SpinningFish.Services.Shop.Models;

namespace SpinningFish.Services.Shop
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandListingServiceModel>> AllListingAsync();

        
    }
}

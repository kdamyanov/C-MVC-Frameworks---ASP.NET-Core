using System.Collections.Generic;
using System.Threading.Tasks;
using SpinningFish.Services.Shop.Models;

namespace SpinningFish.Services.Shop
{
    public interface IReelService
    {
        Task<IEnumerable<ReelListingServiceModel>> AllReelsByIdBrandAsync(int id);

        Task<IEnumerable<ReelListingServiceModel>> AllReelsAsync();

        Task<IEnumerable<ReelListingServiceModel>> DetailsReelByIdAsync(int id);


    }
}

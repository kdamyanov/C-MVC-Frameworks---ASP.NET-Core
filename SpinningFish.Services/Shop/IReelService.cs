namespace SpinningFish.Services.Shop
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReelService
    {
        Task<IEnumerable<ReelListingServiceModel>> AllReelsByIdBrandAsync(int id);

        Task<IEnumerable<ReelListingServiceModel>> AllReelsAsync();

        Task<IEnumerable<ReelListingServiceModel>> DetailsReelByIdAsync(int id);


    }
}

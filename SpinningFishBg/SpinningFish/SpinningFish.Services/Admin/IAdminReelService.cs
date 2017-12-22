using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpinningFish.Data.Models;
using SpinningFish.Services.Admin.Models;
using SpinningFish.Services.Shop.Models;

namespace SpinningFish.Services.Admin
{
    public interface IAdminReelService
    {
        Task Create(
            string model, 
            string description, 
            string details, 
            string videoId, 
            DateTime addedOnDate, 
            decimal price, 
            int quantity, 
            CategoryType category, 
            byte[] image,
            int brandId);

        Task<IEnumerable<AdminReelListingServiceModel>> AllListindAsync();

        ReelDetailsModel ById(int id);

        Task Edit(
            int id,
            string model,
            string description,
            string details,
            string videoId,
            DateTime аddedOnDate,
            decimal price,
            int quantity,
            CategoryType category);

        Task Delete(int id);
    }
}

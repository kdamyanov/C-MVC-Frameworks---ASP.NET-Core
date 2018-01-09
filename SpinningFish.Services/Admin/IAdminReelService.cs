namespace SpinningFish.Services.Admin
{
    using Data.Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

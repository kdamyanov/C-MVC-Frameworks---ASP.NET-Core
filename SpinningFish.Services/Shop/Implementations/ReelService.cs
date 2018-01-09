namespace SpinningFish.Services.Shop.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReelService : IReelService
    {
        private readonly SpinningFishDbContext db;

        public ReelService(SpinningFishDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<ReelListingServiceModel>> AllReelsByIdBrandAsync(int id)
        {
            var result =await this.db
                .Reels
                .OrderByDescending(r => r.Id)
                .Where(b => b.BrandId == id)
                .Select(r => new ReelListingServiceModel
                {
                    Id = r.Id,
                    Model = r.Model,
                    Description = r.Description,
                    Details = r.Details,
                    VideoId = r.VideoId,
                    АddedOnDate = r.АddedOnDate,
                    Price = r.Price,
                    Quantity = r.Quantity,
                    Category = r.Category,
                    Image = r.Image

                }).ToListAsync();

            return result;
        }

        public async  Task<IEnumerable<ReelListingServiceModel>> AllReelsAsync()
         => await this.db
                .Reels
                .ProjectTo<ReelListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<ReelListingServiceModel>> DetailsReelByIdAsync(int id)
        {
            var result = await this.db
                .Reels
                .Where(r => r.Id == id)
                .Select(r => new ReelListingServiceModel
                {
                    Id = r.Id,
                    Model = r.Model,
                    Description = r.Description,
                    Details = r.Details,
                    VideoId = r.VideoId,
                    АddedOnDate = r.АddedOnDate,
                    Price = r.Price,
                    Quantity = r.Quantity,
                    Category = r.Category,
                    Image = r.Image

                }).ToListAsync();

            return result;
        }

        
    }
}

namespace SpinningFish.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminReelService : IAdminReelService
    {
        private readonly SpinningFishDbContext db;

        public AdminReelService(SpinningFishDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminReelListingServiceModel>> AllListindAsync()
            => await this.db
                .Reels
                .ProjectTo<AdminReelListingServiceModel>()
                .ToListAsync();

        public ReelDetailsModel ById(int id)
            => this.db
                .Reels
                .Where(r => r.Id == id)
                .Select(p => new ReelDetailsModel
                {
                    Model = p.Model,
                    Description = p.Description,
                    Details = p.Details,
                    VideoId = p.VideoId,
                    АddedOnDate = p.АddedOnDate,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Category = p.Category,

                })
                .FirstOrDefault();

        

        public async Task Create(
            string model, 
            string description, 
            string details, 
            string videoId, 
            DateTime addedOnDate, 
            decimal price,
            int quantity, 
            CategoryType category, 
            byte[] image, 
            int brandId)
        {
            var reel = new Reel
            {
                Model = model,
                Description = description,
                Details = details,
                VideoId = videoId,
                АddedOnDate = addedOnDate,
                Price = price,
                Quantity = quantity,
                Category = category,
                Image = image,
                BrandId = brandId
            };

            this.db.Add(reel);
            await this.db.SaveChangesAsync();
        }

        public async Task Edit(int id, string model, string description, string details, string videoId, DateTime аddedOnDate, decimal price,
            int quantity, CategoryType category)
        {
            var reel = this.db.Reels.Find(id);

            if (reel == null)
            {
                return;
            }

            reel.Model = model;
            reel.Description = description;
            reel.Details = details;
            reel.VideoId = videoId;
            reel.АddedOnDate = аddedOnDate;
            reel.Price = price;
            reel.Quantity = quantity;
            reel.Category = category;

            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var reel = await this.db.Reels.FindAsync(id);

            if (reel == null)
            {
                return;
            }

           this.db.Reels.Remove(reel);
           await this.db.SaveChangesAsync();
        }
    }
}

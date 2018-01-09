namespace SpinningFish.Services.Shop.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BrandService : IBrandService
    {
        private readonly SpinningFishDbContext db;

        public BrandService(SpinningFishDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<BrandListingServiceModel>> AllListingAsync()
            => await this.db
                .Brands
                .ProjectTo<BrandListingServiceModel>()
                .ToListAsync();

        
    }
}

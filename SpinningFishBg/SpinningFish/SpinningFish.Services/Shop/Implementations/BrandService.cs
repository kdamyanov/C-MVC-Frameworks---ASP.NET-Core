using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SpinningFish.Data;
using SpinningFish.Services.Admin.Models;
using SpinningFish.Services.Shop.Models;

namespace SpinningFish.Services.Shop.Implementations
{
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

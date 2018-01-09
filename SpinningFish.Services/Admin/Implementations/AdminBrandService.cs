using System.Linq;

namespace SpinningFish.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminBrandService :IAdminBrandService
    {
        private readonly SpinningFishDbContext db;

        public AdminBrandService(SpinningFishDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminBrandListingServiceModel>> AllListindAsync() 
            => await this.db
            .Brands
            .ProjectTo<AdminBrandListingServiceModel>()
            .ToListAsync();

        public IEnumerable<BrandModel> All()
            => this.db
                .Brands
                .OrderBy(b => b.Name)
            .Select(b => new BrandModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

        public async Task Create(string name, string description, byte[] image)
        {
            var brand = new Brand
            {
                Name = name,
                Description = description,
                Image = image
            };

            this.db.Add(brand);
            await this.db.SaveChangesAsync();
        }

        
    }
}

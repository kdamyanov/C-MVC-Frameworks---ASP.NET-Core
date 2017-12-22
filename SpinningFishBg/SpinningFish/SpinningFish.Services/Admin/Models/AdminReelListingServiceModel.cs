using System;
using SpinningFish.Common.Mapping;
using SpinningFish.Data.Models;

namespace SpinningFish.Services.Admin.Models
{
    public class AdminReelListingServiceModel : IMapFrom<Reel>
    {
        public string Id { get; set; }
        
        public string Model { get; set; }

        public DateTime АddedOnDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public CategoryType Category { get; set; }

        public byte[] Image { get; set; }
    }
}

using System;
using SpinningFish.Common.Mapping;
using SpinningFish.Data.Models;

namespace SpinningFish.Services.Shop.Models
{
    public class ReelListingServiceModel : IMapFrom<Reel>
    {
        public int Id { get; set; }
        
        public string Model { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string VideoId { get; set; }

        public DateTime АddedOnDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public CategoryType Category { get; set; }

        public byte[] Image { get; set; }
    }
}

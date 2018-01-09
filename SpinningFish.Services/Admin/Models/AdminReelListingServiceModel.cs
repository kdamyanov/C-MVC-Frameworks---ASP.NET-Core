namespace SpinningFish.Services.Admin.Models
{
    using Common.Mapping;
    using Data.Models;
    using System;

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

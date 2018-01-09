namespace SpinningFish.Services.Admin.Models
{
    using Data.Models;
    using System;

    public class ReelDetailsModel
    {
        public string Model { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string VideoId { get; set; }

        public DateTime АddedOnDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public CategoryType Category { get; set; }
        
    }
}

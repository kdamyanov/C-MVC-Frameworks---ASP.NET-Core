namespace SpinningFish.Services.Admin.Models
{
    using Common.Mapping;
    using Data.Models;

    public class AdminBrandListingServiceModel : IMapFrom<Brand>
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}

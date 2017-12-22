namespace SpinningFish.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BrandNameMinLength)]
        [MaxLength(BrandNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(ImageFileLength)]
        public byte[] Image { get; set; }

        public List<Reel> Reels { get; set; } = new List<Reel>();


    }
}

using System;

namespace SpinningFish.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Reel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ReelModelMinLength)]
        [MaxLength(ReelModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Details { get; set; }

        [Required]
        [MinLength(VideoIdLength)]
        [MaxLength(VideoIdLength)]
        public string VideoId { get; set; }

        public DateTime АddedOnDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(ImageFileLength)]
        public byte[] Image { get; set; }

        public CategoryType Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }


    }
}

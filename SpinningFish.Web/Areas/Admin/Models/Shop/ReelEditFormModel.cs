namespace SpinningFish.Web.Areas.Admin.Models.Shop
{
    using Data;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReelEditFormModel
    {
        [Required]
        [Display(Name = "Model:")]
        [MinLength(DataConstants.ReelModelMinLength)]
        [MaxLength(DataConstants.ReelModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DataConstants.DescriptionMaxLength, ErrorMessage = "The Description must be max {1} characters long.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "YouTube Video URL:")]
        [MinLength(DataConstants.VideoIdLength)]
        [MaxLength(DataConstants.VideoIdLength)]
        public string VideoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime АddedOnDate { get; set; }

        [Required]
        [Display(Name = "Price:")]
        [RegularExpression(@"^\d*\.?\d{0,2}$", ErrorMessage = "The Price must have precision up to 2 digits after floating point.")]
        [Range(0.01,999999999, ErrorMessage = "Price must be greater than 0.00 and smaller then one billion.")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Quantity must be greater than 0.00 and smaller then 100.")]
        [Display(Name = "Quantity:")]
        public int Quantity { get; set; }

        [Display(Name = "Category:")]
        public CategoryType Category { get; set; }
    }
}

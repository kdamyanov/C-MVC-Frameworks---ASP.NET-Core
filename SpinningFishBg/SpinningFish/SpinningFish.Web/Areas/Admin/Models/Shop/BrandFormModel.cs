namespace SpinningFish.Web.Areas.Admin.Models.Shop
{
    using Data;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BrandFormModel : IValidatableObject
    {
        [Required]
        [Display(Name = "Name:")]
        [MinLength(DataConstants.BrandNameMinLength, ErrorMessage = "The Name must be at least 2 and at max 20 characters long.")]
        [MaxLength(DataConstants.BrandNameMaxLength, ErrorMessage = "The Name must be at least 2 and at max 20 characters long.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description:")]
        [MaxLength(DataConstants.DescriptionMaxLength, ErrorMessage = "The Description must be max 500 characters long.")]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }


        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!this.Image.FileName.ToLower().EndsWith(".jpg")
                && !this.Image.FileName.ToLower().EndsWith(".png"))
            {
                yield return new ValidationResult("Your Image should be a .jpg or .jpeg or .png file.");

            }

            if (this.Image.Length > DataConstants.ImageFileLength)
                
            {
                yield return new ValidationResult("Your Image should be no more than 2 MB in size.");

            }
        }
    }
}

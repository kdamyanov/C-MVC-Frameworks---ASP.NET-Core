using System.ComponentModel.DataAnnotations;

namespace SpinningFish.Web.Models.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

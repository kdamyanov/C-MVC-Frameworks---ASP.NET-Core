using System.ComponentModel.DataAnnotations;

namespace SpinningFish.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

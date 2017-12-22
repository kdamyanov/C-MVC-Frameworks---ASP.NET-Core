namespace SpinningFish.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Postcode { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

    }
}

namespace SpinningFish.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}

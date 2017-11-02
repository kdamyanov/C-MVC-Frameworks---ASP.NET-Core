﻿namespace FluffyDuffyMunchkinCats.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        private const int StringMaxLenght = 50;

        public int Id { get; set; }

        [Required]
        [MaxLength(StringMaxLenght)]
        public string Name { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        [MaxLength(StringMaxLenght)]
        public string Breed { get; set; }

        [Required]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}

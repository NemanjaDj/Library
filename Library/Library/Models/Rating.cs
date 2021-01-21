﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Rating
    {
        [Required]
        [Key]
        public int RatingId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
        public int? rate { get; set; }
    }
}

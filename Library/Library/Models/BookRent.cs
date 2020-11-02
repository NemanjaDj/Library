﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookRent
    {
        [Key]
        public int RentId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DataTo { get; set; }
    }
}

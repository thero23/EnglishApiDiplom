﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishApi.Models
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.MVC.Models.AAA
{
    public class UpdateUserViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}

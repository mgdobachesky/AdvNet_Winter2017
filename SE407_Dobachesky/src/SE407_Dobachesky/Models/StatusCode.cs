﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class StatusCode
    {
        public Guid StatusCodeId { get; set; }

        [Required(ErrorMessage = "Status Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Status Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Status Name is 50 characters!")]
        public string StatusName { get; set; }
    }
}

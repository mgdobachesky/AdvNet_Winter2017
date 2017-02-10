using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class County
    {
        public Guid CountyId { get; set; }

        [Required(ErrorMessage = "County Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for County Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for County Name is 50 characters!")]
        public string CountyName { get; set; }
    }
}

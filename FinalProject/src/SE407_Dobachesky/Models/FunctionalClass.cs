using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class FunctionalClass
    {
        public Guid FunctionalClassId { get; set; }

        [Required(ErrorMessage = "Functional Class Type is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Functional Class Type is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Functional Class Type is 50 characters!")]
        public string FunctionalClassType { get; set; }
    }
}

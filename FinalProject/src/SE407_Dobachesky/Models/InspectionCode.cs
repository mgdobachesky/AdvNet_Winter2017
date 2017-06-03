using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class InspectionCode
    {
        public Guid InspectionCodeId { get; set; }

        [Required(ErrorMessage = "Inspection Code Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Inspection Code Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Inspection Code Name is 50 characters!")]
        public string InspectionCodeName { get; set; }

        [Required(ErrorMessage = "Inspection Code Description is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Inspection Code Description is 5 characters!")]
        [MaxLength(400, ErrorMessage = "Maximum length for Inspection Code Description is 400 characters!")]
        public string InspectionCodeDesc { get; set; }
    }
}

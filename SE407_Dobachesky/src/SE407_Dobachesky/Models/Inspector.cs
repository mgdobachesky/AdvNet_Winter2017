using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class Inspector
    {
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Inspector First Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Inspector First Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Inspector First Name is 50 characters!")]
        public string InspectorFirst { get; set; }

        [Required(ErrorMessage = "Inspector Last Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Inspector Last Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Inspector Last Name is 50 characters!")]
        public string InspectorLast { get; set; }

        [Required(ErrorMessage = "Inspector Organization is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Inspector Organization is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Inspector Organization is 50 characters!")]
        public string InspectorOrg { get; set; }

        [Required(ErrorMessage = "Inspecter Certification Effective date is required!")]
        public DateTime InspectorCertEffective { get; set; }

        [Required(ErrorMessage = "Inspector Certification Expire date is required!")]
        public DateTime InspectorCertExpires { get; set; }
    }
}

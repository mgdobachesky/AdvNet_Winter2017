using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class MaintenanceAction
    {
        public Guid MaintenanceActionId { get; set; }

        [Required(ErrorMessage = "Maintenance Action Name is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Maintenance Action Name is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Maintenance Action Name is 50 characters!")]
        public string MaintenanceActionName { get; set; }
    }
}

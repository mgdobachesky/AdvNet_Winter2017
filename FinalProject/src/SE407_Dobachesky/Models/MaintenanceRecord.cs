using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class MaintenanceRecord
    {
        public Guid MaintenanceRecordId { get; set; }

        [Required(ErrorMessage = "Maintenance Action is required!")]
        public Guid MaintenanceActionId { get; set; }

        [Required(ErrorMessage = "Inspector is required!")]
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Maintenance Projected Start date is required!")]
        public DateTime MaintenanceProjectedStart { get; set; }

        [Required(ErrorMessage = "Maintenance Projected End date is required!")]
        public DateTime MaintenanceProjectedEnd { get; set; }

        public DateTime MaintenanceActualStart { get; set; }

        public DateTime MaintenanceActualEnd { get; set; }

        [Required(ErrorMessage = "Maintenance Projected Cost is required!")]
        public decimal MaintenanceProjectedCost { get; set; }

        public decimal MaintenanceActualCost { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum length for Maintenence Notes is 1,000 characters!")]
        public string MaintenanceNotes { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum length for Inspector Notes is 1,000 characters!")]
        public string InspectorNotes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class MaintenanceRecords
    {
        [Key]
        public Guid MaintenaceId { get; set; }
        public Guid MaintenanceActionId { get; set; }
        public Guid InspectorId { get; set; }
        public DateTime MaintenanceProjectedStart { get; set; }
        public DateTime MaintenanceProjectedEnd { get; set; }
        public DateTime MaintenanceActualStart { get; set; }
        public DateTime MaintenanceActualEnd { get; set; }
        public decimal MantenanceProjectedCost { get; set; }
        public decimal MaintenanceActualCost { get; set; }
        public string MaintenanceNotes { get; set; }
        public string InspectorNotes { get; set; }
    }
}

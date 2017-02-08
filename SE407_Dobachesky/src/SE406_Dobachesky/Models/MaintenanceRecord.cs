using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class MaintenanceRecord
    {
        public Guid MaintenanceRecordId { get; set; }
        public Guid MaintenanceActionId { get; set; }
        public Guid InspectorId { get; set; }
        public DateTime MaintenanceRecordProjectedStart { get; set; }
        public DateTime MaintenanceRecordProjectedEnd { get; set; }
        public DateTime MaintenanceRecordActualStart { get; set; }
        public DateTime MaintenanceRecordActualEnd { get; set; }
        public decimal MantenanceRecordProjectedCost { get; set; }
        public decimal MaintenanceRecordActualCost { get; set; }
        public string MaintenanceRecordNotes { get; set; }
        public string InspectorNotes { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class MaintenanceRecords
    {
        public int MaintenanceId { get; set; }
        public int MaintenanceActionId { get; set; }
        public int InspectorId { get; set; }
        public DateTime MaintenanceProjectedStart { get; set; }
        public DateTime MaintenanceProjectedEnd { get; set; }
        public DateTime MaintenanceActualStart { get; set; }
        public DateTime MaintenanceActualEnd { get; set; }
        public decimal MaintenanceProjectedCost { get; set; }
        public decimal MaintenanceActualCost { get; set; }
        public string MaintenanceNotes { get; set; }
        public string InspectorNotes { get; set; }
    }
}

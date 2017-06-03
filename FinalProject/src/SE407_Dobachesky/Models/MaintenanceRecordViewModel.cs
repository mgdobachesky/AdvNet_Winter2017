using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SE407_Dobachesky
{
    public class MaintenanceRecordViewModel
    {
        public List<MaintenanceRecord> MaintenanceRecordsList { get; set; }
        public MaintenanceRecord NewMaintenanceRecord { get; set; }
        public List<SelectListItem> MaintenanceActions { get; set; }
        public List<SelectListItem> Inspectors { get; set; }
    }
}

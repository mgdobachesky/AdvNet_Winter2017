using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class maintenace
    {
        public int maint_id { get; set; }
        public int maint_action_id { get; set; }
        public int inspector_id { get; set; }
        public DateTime maint_projected_start { get; set; }
        public DateTime maint_projected_end { get; set; }
        public DateTime maint_actual_start { get; set; }
        public DateTime maint_actual_end { get; set; }
        public decimal maint_proj_cost { get; set; }
        public decimal maint_actual_cost { get; set; }
        public string maint_notes { get; set; }
        public string maint_inspector_notes { get; set; }
    }
}

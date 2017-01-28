using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class bridge_inventory
    {
        public int bridge_id { get; set; }
        public int material_design_id { get; set; }
        public int construction_design_id { get; set; }
        public int functional_class_id { get; set; }
        public int status_id { get; set; }
        public int county_id { get; set; }
        public string nbi_num { get; set; }
        public decimal rating { get; set; }
        public string route_num { get; set; }
        public string city { get; set; }
        public string intersecting_feature { get; set; }
        public string carried_feature { get; set; }
        public string location { get; set; }
        public int built { get; set; }
        public int reconstructed { get; set; }
        public decimal length { get; set; }
    }
}

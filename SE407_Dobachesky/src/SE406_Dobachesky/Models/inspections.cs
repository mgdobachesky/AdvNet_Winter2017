using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class inspections
    {
        public int inspection_id { get; set; }
        public int bridge_id { get; set; }
        public int inspector_id { get; set; }
        public DateTime inspection_date { get; set; }
        public int deck_inspection_code_id { get; set; }
        public int superstructure_inspection_code_id { get; set; }
        public int substructure_inspection_code_id { get; set; }
        public string inspection_notes { get; set; }
    }
}

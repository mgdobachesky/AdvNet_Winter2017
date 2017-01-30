using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class Inspections
    {
        public int InspectionId { get; set; }
        public int BridgeId { get; set; }
        public int InspectorId { get; set; }
        public DateTime InspectionDate { get; set; }
        public int DeckInspectionCodeId { get; set; }
        public int SuperstructureInspectionCodeId { get; set; }
        public int SubstructureInspectionCodeId { get; set; }
        public string InspectionNotes { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class Inspection
    {
        public Guid InspectionId { get; set; }
        public Guid BridgeId { get; set; }
        public Guid InspectorId { get; set; }
        public DateTime InspectionDate { get; set; }
        public Guid DeckInspectoinCodeId { get; set; }
        public Guid SuperstructureInspectionCodeId { get; set; }
        public Guid SubstructureInspectionCodeId { get; set; }
        public string InspectionNotes { get; set; }
    }
}

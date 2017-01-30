using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class Bridges
    {
        public int BridgeId { get; set; }
        public int MaterialDesignId { get; set; }
        public int ConstructionDesignId { get; set; }
        public int FunctionalClassId { get; set; }
        public int StatusId { get; set; }
        public int CountyId { get; set; }
        public string NbiNumber { get; set; }
        public decimal Rating { get; set; }
        public string RouteNumber { get; set; }
        public string City { get; set; }
        public string IntersectingFeature { get; set; }
        public string CarriedFeature { get; set; }
        public string Location { get; set; }
        public int Built { get; set; }
        public int Reconstructed { get; set; }
        public decimal TotalLength { get; set; }
    }
}

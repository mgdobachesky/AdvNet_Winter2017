using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE407_Dobachesky
{
    public class Inspector
    {
        public Guid InspectorId { get; set; }
        public string InspectorFirst { get; set; }
        public string InspectorLast { get; set; }
        public string InspectorOrg { get; set; }
        public DateTime InspectorCertEffective { get; set; }
        public DateTime InspectorCertExpires { get; set; }
    }
}

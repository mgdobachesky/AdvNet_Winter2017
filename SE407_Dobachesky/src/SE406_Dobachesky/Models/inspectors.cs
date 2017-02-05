using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class Inspectors
    {
        [Key]
        public Guid InspectorId { get; set; }
        public string InspectorFirst { get; set; }
        public string InspectorLast { get; set; }
        public string InspectorOrg { get; set; }
        public DateTime InspectorCertEffective { get; set; }
        public DateTime InspectorCertExpires { get; set; }
    }
}

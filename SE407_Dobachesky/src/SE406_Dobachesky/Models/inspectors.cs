using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class inspectors
    {
        public int inspector_id { get; set; }
        public string inspector_first { get; set; }
        public string inspector_last { get; set; }
        public string inspector_org { get; set; }
        public DateTime inspector_cert_effective { get; set; }
        public DateTime inspector_cert_expires { get; set; }
    }
}

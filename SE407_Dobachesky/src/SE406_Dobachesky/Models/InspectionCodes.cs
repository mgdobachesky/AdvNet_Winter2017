using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class InspectionCodes
    {
        [Key]
        public Guid InspectionCodeId { get; set; }
        public string InspectionCodeName { get; set; }
        public string InspectoinCodeDesc { get; set; }
    }
}

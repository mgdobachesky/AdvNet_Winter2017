using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class MaintenanceActions
    {
        [Key]
        public Guid MaintenanceActionId { get; set; }
        public string MaintenanceActionName { get; set; }
    }
}

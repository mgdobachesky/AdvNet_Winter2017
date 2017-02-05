using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class StatusCodes
    {
        [Key]
        public Guid StatusId { get; set; }
        public string StatusName { get; set; }
    }
}

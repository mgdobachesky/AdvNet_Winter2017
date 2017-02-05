using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class Counties
    {
        [Key]
        public Guid CountyId { get; set; }
        public string CountyName { get; set; }
    }
}

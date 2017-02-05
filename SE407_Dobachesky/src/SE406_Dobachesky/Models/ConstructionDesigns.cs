using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class ConstructionDesigns
    {
        [Key]
        public Guid ConstructionDesignId { get; set; }
        public string ConstructionDesignType { get; set; }
    }
}

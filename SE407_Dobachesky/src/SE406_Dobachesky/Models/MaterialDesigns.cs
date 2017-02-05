using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class MaterialDesigns
    {
        [Key]
        public Guid MaterialDesignId { get; set; }
        public string MaterialDesignType { get; set; }
    }
}

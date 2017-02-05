using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE406_Dobachesky
{
    public class FunctionalClasses
    {
        [Key]
        public Guid FunctionalClassId { get; set; }
        public string FunctionalClassType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class MaterialDesign
    {
        public Guid MaterialDesignId { get; set; }

        [Required(ErrorMessage = "Material Design Type is required!")]
        [MinLength(5, ErrorMessage = "Minimum length for Material Design Type is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length for Material Design Type is 50 characters!")]
        public string MaterialDesignType { get; set; }
    }
}

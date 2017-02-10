using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class Bridge
    {
        public Guid BridgeId { get; set; }

        [Required(ErrorMessage = "Material Design is required!")]
        public Guid MaterialDesignId { get; set; }

        [Required(ErrorMessage = "Construction Design is required!")]
        public Guid ConstructionDesignId { get; set; }

        [Required(ErrorMessage = "Functional Class is required!")]
        public Guid FunctionalClassId { get; set; }

        [Required(ErrorMessage = "Status is required!")]
        public Guid StatusId { get; set; }

        [Required(ErrorMessage = "County is required!")]
        public Guid CountyId { get; set; }

        [Required(ErrorMessage = "NBI Number is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of NBI Number is 5 characters!")]
        [MaxLength(100, ErrorMessage = "Maximum length of NBI Number is 100 characters!")]
        public string NbiNumber { get; set; }

        public decimal? Rating { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length of Route Number is 25 characters!")]
        public string RouteNumber { get; set; }

        [Required(ErrorMessage = "City is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of City is 5 characters!")]
        [MaxLength(50, ErrorMessage = "Maximum length of City is 50 characters!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Intersecting Feature is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of Intersecting Feature is 5 characters!")]
        [MaxLength(255, ErrorMessage = "Maximum length of Intersecting Feature is 255 characters!")]
        public string IntersectingFeature { get; set; }

        [Required(ErrorMessage = "Carried Feature is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of Carried Feature is 5 characters!")]
        [MaxLength(255, ErrorMessage = "Maximum length of Carried Feature is 255 characters!")]
        public string CarriedFeature { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        [MinLength(5, ErrorMessage = "Minimum length of Location is 5 characters!")]
        [MaxLength(255, ErrorMessage = "Maximum length of Location is 255 characters!")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Built is required!")]
        [Range(1600, 2025, ErrorMessage = "Built is out of range!")]
        public int Built { get; set; }

        [Range(1600, 2025, ErrorMessage = "Reconstructed is out of range!")]
        public int? Reconstructed { get; set; }

        [Required(ErrorMessage = "Total Length is required!")]
        public decimal TotalLength { get; set; }
    }
}

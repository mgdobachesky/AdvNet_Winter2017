using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE407_Dobachesky
{
    public class Inspection
    {
        public Guid InspectionId { get; set; }

        [Required(ErrorMessage = "Bridge is required!")]
        public Guid BridgeId { get; set; }

        [Required(ErrorMessage = "Inspector is required!")]
        public Guid InspectorId { get; set; }

        [Required(ErrorMessage = "Inspection Date is required!")]
        public DateTime InspectionDate { get; set; }

        [Required(ErrorMessage = "Deck Inspection Code is required!")]
        public Guid DeckInspectionCodeId { get; set; }

        [Required(ErrorMessage = "Superstructure Inspection Code is required!")]
        public Guid SuperstructureInspectionCodeId { get; set; }

        [Required(ErrorMessage = "Substructure Inspection Code is required!")]
        public Guid SubstructureInspectionCodeId { get; set; }

        [MaxLength(2000, ErrorMessage = "Maximum length for Inspection Notes is 2,000 characters!")]
        public string InspectionNotes { get; set; }
    }
}

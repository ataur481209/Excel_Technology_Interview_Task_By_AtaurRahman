using PatientPortal_Client.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal_Client.ViewModels
{
    public class PatientDetailsViewModel
    {
        public PatientDetailsViewModel()
        {
            this.NCD_Ids = new List<int>();
            this.Allergy_Ids = new List<int>();
            this.Allergy_Names = new List<string>();
            this.NCD_Names = new List<string>();
        }

        public int PatientId { get; set; }

        [Required]
        [StringLength(70)]
        public string PatientName { get; set; } = null!;

        public Epilepsy Epilepsy { get; set; }

        public int DiseaseId { get; set; }

        public string? DiseaseName { get; set; }

        public List<int>? NCD_Ids { get; set; }
        public List<int>? Allergy_Ids { get; set; }

        public List<string>? NCD_Names { get; set; }
        public List<string>? Allergy_Names { get; set; }
    }
}

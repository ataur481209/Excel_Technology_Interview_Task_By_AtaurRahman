//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace PatientPortal_Client.Models
//{
//    public class Patient
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int PatientId { get; set; }

//        [Required]
//        [StringLength(70)]
//        public string PatientName { get; set; } = null!;

//        //public string Epilepsy { get; set; } = null!;
//        public Epilepsy Epilepsy { get; set; }

//        [ForeignKey("Disease")]
//        public int DiseaseId { get; set; }
//        public virtual Disease? Disease { get; }

//        public virtual ICollection<NCD_Details>? NCD_Details { get; } = new List<NCD_Details>();

//        public virtual ICollection<Allergies_Details>? Allergies_Details { get; } = new List<Allergies_Details>();
//    }
//}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PatientPortal_Client.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        [StringLength(70)]
        public string PatientName { get; set; } = null!;

        public Epilepsy Epilepsy { get; set; }

        [ForeignKey("Disease")]
        public int DiseaseId { get; set; }
        public virtual Disease? Disease { get; set; }

        // Add these properties
        public virtual ICollection<NCD_Details>? NCD_Details { get; set; } = new List<NCD_Details>();
        public virtual ICollection<Allergies_Details>? Allergies_Details { get; set; } = new List<Allergies_Details>();

        // Add DiseaseName property
        [NotMapped]
        public string? DiseaseName => Disease?.DiseaseName;

        // Add NCD_Ids and Allergy_Ids properties
        [NotMapped]
        public List<int>? NCD_Ids => NCD_Details?.Select(nd => nd.NCD_Id).ToList();
        [NotMapped]
        public List<int>? Allergy_Ids => Allergies_Details?.Select(ad => ad.AllergyId).ToList();

        // Add NCD_Names and Allergy_Names properties
        [NotMapped]
        public List<string>? NCD_Names => NCD_Details?.Select(nd => nd.NCD.NCD_Name).ToList();
        [NotMapped]
        public List<string>? Allergy_Names => Allergies_Details?.Select(ad => ad.Allergy.AllergyName).ToList();
    }
}

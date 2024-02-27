using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal_Client.Models
{
    public class Allergies_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Allergies_Details_Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Allergy")]
        public int AllergyId { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual Allergy? Allergy { get; set; }
    }
}

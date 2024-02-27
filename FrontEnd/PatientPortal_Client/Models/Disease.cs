using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal_Client.Models
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseId { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseName { get; set; } = null!;

        public virtual ICollection<Patient>? Patients { get; } = new List<Patient>();
    }
}

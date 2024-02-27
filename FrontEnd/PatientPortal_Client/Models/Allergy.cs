using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal_Client.Models
{
    public class Allergy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllergyId { get; set; }

        [Required]
        [StringLength(50)]
        public string AllergyName { get; set; } = null!;

        public virtual ICollection<Allergies_Details>? Allergies_Details { get; } = new List<Allergies_Details>();
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientPortal_Client.Models
{
    public class NCD_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCD_Details_Id { get; set; }

        [ForeignKey("NCD")]
        public int NCD_Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public virtual NCD? NCD { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}

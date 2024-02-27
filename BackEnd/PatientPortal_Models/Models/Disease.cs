using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.Models
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseId { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseName { get; set; } = null!;

        public virtual ICollection<Patient>? Patients { get;  } = new List<Patient>();
    }
}

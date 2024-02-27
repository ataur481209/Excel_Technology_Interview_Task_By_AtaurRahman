using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_5.UML_diagram_Class
{

    public class Pharmacist : Clinician
    {
        public string PharmacistNumber { get; set; }

        public void DispenseMedications(int prescriptionNumber)
        {
            // Implementation for dispensing medications based on prescription number
            Console.WriteLine($"Medications dispensed for prescription {prescriptionNumber} by Pharmacist {Name}");
        }
    }
}

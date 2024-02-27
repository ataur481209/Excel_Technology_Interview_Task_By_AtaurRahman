using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_5.UML_diagram_Class
{
    public class Doctor : Clinician
    {
        public string PracticeNumber { get; set; }

        public void CreatePrescription(int patientNumber)
        {
            Console.WriteLine($"Prescription created for patient {patientNumber} by Doctor {Name}");
        }
    }
}

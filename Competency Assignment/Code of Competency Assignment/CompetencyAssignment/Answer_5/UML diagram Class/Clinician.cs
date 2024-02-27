using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_5.UML_diagram_Class
{
    public class Clinician
    {
        public string Name { get; set; }
        public string HospitalName { get; set; }

        public bool Login(string username, string password)
        {
            return true;
        }

        private bool IsSessionExists(string username)
        {
            return true;
        }
    }
}

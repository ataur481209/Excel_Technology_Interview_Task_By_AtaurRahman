using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_6
{
    public class Flowchart
    {
        public void PrintMinNum(int n1, int n2, int n3)
        {
            int min = 0;
            if (n1 < n2)
            {
                min = n1;
            }
            else
            {
                min = n2;
            }

            if (n3 < min)
            {
                min = n3;
            }

            Console.WriteLine($"Minimum Number : {min}");
        }
    }
}

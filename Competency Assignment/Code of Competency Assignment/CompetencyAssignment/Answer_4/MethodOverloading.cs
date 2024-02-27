using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer_4
{
    public class MethodOverloading
    {
        public int Add(int a, int b)
        {
            return a * b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, int c, double b)
        {
            return a * b + c;
        }
    }

}

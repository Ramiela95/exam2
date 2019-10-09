using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy
{
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception exc)
            {
                return default(double);
            }


        }
    }
}

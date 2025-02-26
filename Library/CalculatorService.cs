﻿using System;
using System.ServiceModel;

namespace GettingStartedLib
{
	public class CalculatorService : ICalculator
	{
		public double Add(double n1, double n2)
        {
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            if (n2 == 0)
            {
                return 0;
            }
            double result = n1 / n2;
            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an instance of the WCF Proxy
            CalculatorClient client = new CalculatorClient();

            double value1 = 100;
            double value2 = 15.99;

            //Adding two numbers with the SOAP calculator service
            double result = client.Add(value1, value2);
            Console.WriteLine("{0 + {1}) = {2}", value1, value2, result);
            Console.WriteLine();

            //Subtracting two numbers
            double result2 = client.Subtract(value1, value2);
            Console.WriteLine("{0} - {1}) = {2}", value1, value2, result2);
            Console.WriteLine();

            //Multiplying two numbers
            double result3 = client.Multiply(value1, value2);
            Console.WriteLine("{0} x {1}) = {2}", value1, value2, result3);

            //Dividing two numbers
            double result4 = client.Divide(value1, value2);
            Console.WriteLine("{0} / {1}) = {2}", value1, value2, result4);
            Console.WriteLine();

            double result5 = client.Divide(value1, 0);
            Console.WriteLine("{0} / {1}) = {2}", value1, 0, result5);
            Console.WriteLine();

            //Closing the client
            Console.WriteLine("Press <ENTER> to terminate.");
            Console.WriteLine();
            Console.ReadLine();
            client.Close();
        }
    }
}

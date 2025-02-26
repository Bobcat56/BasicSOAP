using GettingStartedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an instance of the URI class to hold the base address for the service.
            Uri baseAddress = new Uri("http://localhost:80/Tenmporary_Listen_Address/CalculatorService/");

            //Create an instance of the ServiceHost class to host the service.
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                //Creating a service Endpoint. This is composed of an address,a binding, and a service contract.
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                //Enabling metadata exchange. This is required to enable clients to generate a service.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                //Open Service Host to listen fpr the incoming messages.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                //Close the ServiceHost to stop listening for messages.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}

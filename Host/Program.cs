using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFAndEFService;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:80/Temporary_Listen_Address/ProductService");
            ServiceHost selfHost = new ServiceHost(typeof(ProductService), uri);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IProductService), new WSHttpBinding(), "ProductService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to stop the service.");
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

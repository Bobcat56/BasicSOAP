using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient client = new ProductServiceClient();

            int id = 1;

            Console.WriteLine("This program will check the product from the products table.");
            Console.WriteLine("Enter 0 to exit the program.");

            while (id != 0)
            {
                Console.WriteLine("Please enter a product id ranging from 1 to 77");
                id = int.Parse(Console.ReadLine());

                if (id < 0 || id > 77)
                {
                    Console.WriteLine("Invalid product id. Please enter a product id ranging from 1 to 77");
                    Console.WriteLine();
                }
                else if (id == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    ProductEntity product = client.GetProductEntity(id);
                    Console.WriteLine("Product ID: {0}", product.ProductID);
                    Console.WriteLine("Product Name: {0}", product.ProductName);
                    Console.WriteLine("Quantity Per Unit: {0}", product.QuantityPerUnit);
                    Console.WriteLine("Unit Price: {0}", product.UnitPrice);
                    Console.WriteLine("Discontinued: {0}", product.Discontinued);
                    Console.WriteLine();
                }
            }
            client.Close();
        }
    }
}

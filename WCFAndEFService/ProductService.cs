using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAndEFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public ProductEntity GetProductEntity(int id)
        {
            NorthwindEntities context = new NorthwindEntities();

            var product = (from p in context.Products
                           where p.ProductID == id
                           select p).FirstOrDefault();

            if (product != null)
            {
                return TranslateProductToProductentity(product);
            }
            else
            {
                throw new Exception("Invalid product ID");
            }
        }

        private ProductEntity TranslateProductToProductentity(Product product)
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.ProductID = product.ProductID;
            productEntity.ProductName = product.ProductName;
            productEntity.QuantityPerUnit = product.QuantityPerUnit;
            productEntity.UnitPrice = (decimal)product.UnitPrice;
            productEntity.Discontinued = product.Discontinued;
             
            return productEntity;
        }
    }
}

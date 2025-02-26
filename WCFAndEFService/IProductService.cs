using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAndEFService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductEntity GetProductEntity(int id);
    }

    [DataContract]
    public class ProductEntity
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string QuantityPerUnit { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public bool Discontinued { get; set; }
    }
}

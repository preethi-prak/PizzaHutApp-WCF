using PizzaHut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    [ServiceContract]
    public interface IPizzaHut
    {
        [OperationContract]
        List<Product> GetProducts();
        [OperationContract]
        List<Customer> GetCustomers();
        [OperationContract]
        void SubmitOrder(Order order); 
    }
}

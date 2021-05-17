using PizzaHut.Data;
using PizzaHut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHut.Services
{
    //Per call , Per session , single 
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PizzaHutService : IPizzaHut,IDisposable
    {
        readonly PizzaHutDbContext _context = new PizzaHutDbContext();       

        [PrincipalPermission(SecurityAction.Demand,Role = "BUILTIN\\Administrators")]
        public List<Customer> GetCustomers()
        {
            var pricipal = Thread.CurrentPrincipal;
            if (!pricipal.IsInRole("BUILTIN\\Administrators"))
                throw new SecurityException("Access Denied");
            //ClaimPrincipal.Current.HasClaim()
            return _context.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SubmitOrder(Order order)
        {
            _context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _context.OrderItems.Add(oi));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

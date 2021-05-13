using PizzaHut.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHut.SelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(PizzaHutService));
            host.Open();
            Console.WriteLine("Hit Any key to exit");
            Console.ReadKey();
            host.Close();

        }
    }
}

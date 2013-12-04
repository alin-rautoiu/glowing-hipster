using Autofac;
using CustomerService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = GetAutofacContainer();

            ICustomerRepository customerRepository = GetCustomerRepository();

            var customers = customerRepository.GetAllCustomers();

            foreach (var customer in customers)
            {
                var customerString =
                    string.Format("Id = {0} FirstName = {1} LastName = {2}",
                        customer.Id, customer.FirstName, customer.LastName);
                
                Console.WriteLine(customerString);
                
            }
        }

        private static IContainer GetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();

            var container = builder.Build();
            return container;
        }

        private static ICustomerRepository GetCustomerRepository()
        {
            ICustomerRepository customerRepository;

            using (var scope = Container.BeginLifetimeScope())
            {
                customerRepository = scope.Resolve<ICustomerRepository>();
            }

            return customerRepository;
        }
    }
}

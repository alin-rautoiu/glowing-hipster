using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Core
{
    public class CustomerRepository : ICustomerRepository
    {
        private IOrdersRepository ordersService { get; set; }
        public IList<Customer> Customers { get; set; }

        public CustomerRepository(IOrdersRepository ordersService)
        {
            this.ordersService = ordersService;

            Customers = new List<Customer>() { 
                new Customer {
                    Id = 1,
                    FirstName = "firstName1",
                    LastName = "lastName1"
                },
                new Customer {
                    Id = 2,
                    FirstName = "firstName2",
                    LastName = "lastName2"
                },
                new Customer {
                    Id  = 3,
                    FirstName = "firstName3",
                    LastName = "lastName3"
                }
            };
        }

        public Customer GetCustomer(int id)
        {
            return Customers.Where(c => c.Id == id).SingleOrDefault();
        }

        public IList<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.LastName)
                || string.IsNullOrEmpty(customer.FirstName))
            {
                throw new Exception("The first name or last name of the customer is null or empty");
            }

            Customers.Add(customer);
        }

        public IList<Order> GetOrders(int customerId)
        {
            return ordersService.GetOrders(customerId);
        }
    }

    public interface ICustomerRepository
    {
        IList<Customer> Customers { get; set; }

        Customer GetCustomer(int id);

        IList<Customer> GetAllCustomers();
        
        void AddCustomer(Customer customer);
    }

    public class Customer
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}

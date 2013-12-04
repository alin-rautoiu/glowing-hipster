using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Core
{
    public class OrdersRepository : IOrdersRepository
    {
        public IList<Order> Orders { get; set; }

        public OrdersRepository()
        {
            Orders = new List<Order>() {
                new Order {
                    Id = 1,
                    CustomerId = 1,
                    Data = DateTime.Now,
                    Valoare = 10
                },
                new Order {
                    Id = 2,
                    CustomerId = 2,
                    Data = DateTime.Now,
                    Valoare = 20
                },
                new Order {
                    Id = 3,
                    CustomerId = 1,
                    Data = DateTime.Now,
                    Valoare = 30
                }
            };
        }

        public IList<Order> GetOrders(int customerId)
        {
            return Orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }

    public interface IOrdersRepository
    {
        IList<Order> Orders { get; set; }
        IList<Order> GetOrders(int customerId);
    }

    public class Order
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public float Valoare { get; set; }

        public int CustomerId { get; set; }
    }
}

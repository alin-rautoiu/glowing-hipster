using CustomerService.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Tests
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestMethod]
        public void GivenAValidCustomerIdWhenGetCustomerByIdThenIWillGetAValidCustomerFromRepository()
        {
            //arrange
            const int customerId = 1;
            const string fName = "Ion";
            const string lName = "Popescu";

            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);
            service.Customers = new List<Customer> { 
                new Customer
                {
                    Id = 1,
                    FirstName = fName,
                    LastName = lName
                },
                new Customer
                {
                    Id = 2,
                    FirstName = fName,
                    LastName = lName
                },
            };

            //Act
            var customer = service.GetCustomer(customerId);

            //Assert
            Assert.IsTrue(customer != null);
            Assert.IsTrue(customer.Id == customerId);
            Assert.IsTrue(customer.FirstName == fName);
            Assert.IsTrue(customer.LastName == lName);
        }

        [TestMethod]
        public void GivenACustomerWhenAddCustomerThenTheSaveMethodOfTheCollectionIsCalled()
        {
            //arrange
            var mockCustomers = new Mock<IList<Customer>>();
            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);
            service.Customers = mockCustomers.Object;

            //act
            service.AddCustomer(new Customer
            {
                FirstName = "firstName",
                LastName = "lastName"
            });

            //assert
            mockCustomers.Verify((m => m.Add(It.IsAny<Customer>())), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenACustomerWithFirstNameEmptyWhenAddCustomerThenAnExceptionIsRaised()
        {
            //arrange
            var mockCustomers = new Mock<IList<Customer>>();
            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);
            service.Customers = mockCustomers.Object;

            //act
            service.AddCustomer(new Customer
            {
                FirstName = "",
                LastName = "lastName"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenACustomerWithLastNameEmptyWhenAddCustomerThenAnExceptionIsRaised()
        {
            //arrange
            var mockCustomers = new Mock<IList<Customer>>();
            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);
            service.Customers = mockCustomers.Object;

            //act
            service.AddCustomer(new Customer
            {
                FirstName = "firstName",
                LastName = ""
            });
        }

        [TestMethod]
        public void GivenNothingWhenGetAllCustomerThenReceivedAllCustomers()
        {
            //arrange
            var customersExpected = new List<Customer>();
            customersExpected.Add(new Customer
                {
                    FirstName = "firstName1",
                    LastName = "lastName1"
                });
            customersExpected.Add(new Customer
            {
                FirstName = "firstName2",
                LastName = "lastName2"
            });
            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);
            service.Customers = customersExpected;

            //act
            var customers = service.GetAllCustomers();

            //assert
            Assert.AreEqual(customersExpected, customers);
        }

        [TestMethod]
        public void GivenACostumerIdWhenCallGetOrdersThenGetOrdersOfOrdersRepositoryIsCalled()
        {
            //arrange
            var ordersService = new Mock<IOrdersRepository>();
            var service = new CustomerService.Core.CustomerRepository(ordersService.Object);

            //act
            var ordersResult = service.GetOrders(1);

            //assert
            ordersService.Verify(m => m.GetOrders(1), Times.Exactly(1));
            ordersService.Verify(m => m.GetOrders(It.IsAny<int>()), Times.Exactly(1));
        }
    }
}

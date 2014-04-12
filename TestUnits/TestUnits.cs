using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ControllerInjection.Controllers;
using ControllerInjection.Dependencies;
using System.Web.Mvc;
using ControllerInjection.Repository;
using ControllerInjection.Models.EntityFramework;

namespace TestUnits
{
    [TestFixture]
    public class TestUnits
    {
        private  HomeController _homecontroller;
        private  Mock<ILogger> _ilogger;
        private CustomersController customersController;
        private OrdersController orderController;
        private Mock<IRepository<Customer>> mockCustomers;
        private Mock<IRepository<Order>> mockOrders;

        [TestFixtureSetUp]
        public void Init()
        {
            _ilogger = new Mock<ILogger>();
            _ilogger.Setup(r => r.Log("Hello")).Verifiable();           
             mockCustomers = new Mock<IRepository<Customer>>();
             mockOrders = new Mock<IRepository<Order>>();
        }

        [Test]
        public void TestPartialViewCustomerName()
        {
            customersController = new CustomersController(mockCustomers.Object);
            PartialViewResult presult = customersController.AllCustomers("TestName") as PartialViewResult;
            mockCustomers.VerifyAll();
            Assert.AreEqual("AllCustomers", presult.ViewName);
            Assert.AreEqual("This should show as it is in testing", customersController.ViewBag.Test);
        }

        [Test]
        public void TestPartialViewOrderName()
        {
            orderController = new OrdersController(mockOrders.Object);
            PartialViewResult presult = orderController.OrdersForCustomer("TestName") as PartialViewResult;
            mockOrders.VerifyAll();
            Assert.AreEqual("OrdersForCustomer", presult.ViewName);
            Assert.AreEqual("This should show as it is in testing", orderController.ViewBag.Test);
        }

        [Test]
        public void TestIndexViewName()
        {
            _homecontroller = new HomeController(_ilogger.Object);
            ViewResult result = _homecontroller.Index() as ViewResult;
            _ilogger.VerifyAll();
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}

using ControllerInjection.Models.EntityFramework;
using ControllerInjection.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerInjection.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<Order> _ordersRepository;
        public OrdersController(IRepository<Order> orderRepository)
        {
            _ordersRepository = orderRepository;        
        }
        public PartialViewResult OrdersForCustomer(string companyName)
        {
            ViewBag.Test = "This should show as it is in testing";
            var allOrders = _ordersRepository.SearchFor(m=>m.Customer.CompanyName.Equals(companyName));
            return PartialView("OrdersForCustomer", allOrders);
        }
	}
}
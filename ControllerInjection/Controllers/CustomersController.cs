using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerInjection.Repository;
using ControllerInjection.Models.EntityFramework;

namespace ControllerInjection.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;        
        }

        public PartialViewResult AllCustomers(string CustomerName)
        {
            ViewBag.Test = "This should show as it is in testing";
            var customers = _customerRepository.GetAll().Where(m=>m.CompanyName.Contains(CustomerName));
            return PartialView("AllCustomers", customers);
        }
	}
}
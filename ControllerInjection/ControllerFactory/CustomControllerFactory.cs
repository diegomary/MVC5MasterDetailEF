using ControllerInjection.Controllers;
using ControllerInjection.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ControllerInjection.Repository;
using ControllerInjection.Models.EntityFramework;

namespace ControllerInjection.ControllerFactory
{
    public class CustomControllerFactory : IControllerFactory
    {
        private IController controller;
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {          
           switch (controllerName)
           {
                case "Home":            
                ILogger logger = new DefaultLogger();
                controller = new HomeController(logger);               
                break;

                case "Customers":
                IRepository<Customer> customerRepository = new Repository<Customer>(new NORTHWNDEntities());
                controller = new CustomersController(customerRepository);
                break;

                case "Orders":
                IRepository<Order> orderRepository = new Repository<Order>(new NORTHWNDEntities());
                controller = new OrdersController(orderRepository);
                break;

                case "Account":       
                controller = new AccountController();
                break;
            }
           return controller;
        }
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(
           System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    } 
}
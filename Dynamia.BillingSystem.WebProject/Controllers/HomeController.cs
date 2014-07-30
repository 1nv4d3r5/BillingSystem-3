using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dynamia.BillingSystem.SQLDAO;
using Dynamia.BillingSystem.BusinessManager;
using Dynamia.BillingSystem.Controller;

namespace Dynamia.BillingSystem.WebProject.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void runBilling()
        {
            BillingController billingController = new BillingController();
            billingController.CreateDynamiaBilling();
        }

        public void runAnnulation()
        {
            BillingController billingController = new BillingController();
            billingController.AnnulateBilling();
        }
    }
}

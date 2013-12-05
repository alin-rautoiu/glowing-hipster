using PersonsRegistry.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private ContextController lst = new ContextController();

        public ActionResult Index()
        {
            if (lst.Persons.ToList().Count == 0)
            {
                lst.Persons.Add(new PersonsRegistry.Models.Person("Alin", 21, "Student"));
                lst.SaveChanges();
            }

            return View(); }

        public ActionResult About()
        { return View(); }
    }
}
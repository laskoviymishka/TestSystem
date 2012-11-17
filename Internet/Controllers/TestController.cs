using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Internet.Models;

namespace Internet.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        [Authorize]
        public ActionResult Index()
        {
            TestEntities te = new TestEntities();
            if (User.IsInRole("Professor"))
            {
                return View("List",te.Tests);
            }
            return View(te.Tests.ToList());
        }

    }
}

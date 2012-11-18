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
        TestService _service;
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


        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int ID) 
        {
            TestEntities te = new TestEntities();
            return View((Test)te.Tests.Where<Test>(t => t.ID == ID).FirstOrDefault<Test>());
        }
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public ActionResult Edit(Test item)
        {
            _service = new TestService();
            _service.UpdateItem(_service.GetByID(1),item);
            return View();
        }


        [Authorize(Roles = "Professor")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public ActionResult Create(Test item)
        {
            _service = new TestService();
            _service.CreateItem(item);
            return View();
        }
    }
}

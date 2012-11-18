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
        IService<Test> _service;
        public TestController() 
        {
            _service = new TestService();
        }
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
        public ActionResult Delete(int ID)
        {
            _service.DeleteItem(_service.GetByID(ID));
            return View("List", _service.GetItems());
        }

        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int ID) 
        {
            return View(_service.GetByID(ID));
        }
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public ActionResult Edit(int ID,Test item)
        {

            _service.UpdateItem(_service.GetByID(ID), item);
            return View("List", _service.GetItems());
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
            item.TestAuthor = User.Identity.Name;
            _service.CreateItem(item);
            return View("List", _service.GetItems());
        }
        [HttpGet]
        [Authorize(Roles = "Professor")]
        public ActionResult Details(int ID)
        {
            return View(_service.GetByID(ID));
        }
    }
}

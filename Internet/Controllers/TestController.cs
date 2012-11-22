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
        IRepository<Test> _repository;
        public TestController() 
        {
            _repository = new TestRepository();
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
            var url = Url.RouteUrl("Default", new{
                                                    action = "Index",
                                                    controller = "TestPassing"
                                                 });
            Response.Redirect(url);
            return null;
        }
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int ID)
        {
            _repository.DeleteItem(_repository.GetByID(ID));
            return View("List", _repository.GetItems());
        }

        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int ID) 
        {
            return View(_repository.GetByID(ID));
        }
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public ActionResult Edit(int ID,Test item)
        {

            _repository.UpdateItem(_repository.GetByID(ID), item);
            return View("List", _repository.GetItems());
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
            _repository.CreateItem(item);
            return View("List", _repository.GetItems());
        }
        [HttpGet]
        [Authorize(Roles = "Professor")]
        public ActionResult Details(int ID)
        {
            return View(_repository.GetByID(ID));
        }
    }
}

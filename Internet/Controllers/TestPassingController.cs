using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Internet.Models;

namespace Internet.Controllers
{
    public class TestPassingController : Controller
    {
        //
        // GET: /TestPassing/
        IRepository<Test> _repository;
        public TestPassingController() 
        {
            _repository = new TestRepository();
        }

        public ActionResult Index()
        {
            return View(_repository.GetItems());
        }
        public ActionResult Test(int id)
        {
            return View(_repository.GetByID(id));
        }
        [HttpPost]
        public ActionResult Test(int id, FormCollection items)
        {

           /* var winnars = (from x in item.AllKeys
                          where item[x] != "false"
                          select x).ToList<string>();
            Result res = new Result();
            res.TestID = id;
            res.UserName = User.Identity.Name;
            (new ResultRepository()).CreateItem(res);
            AddResult ar = new AddResult(res);
            ar.Score(winnars);
            var url = Url.RouteUrl("Default", new
                                                {
                                                    action = "TestResult/" + res.ID,
                                                    controller = "TestPassing"
                                                });
            Response.Redirect(url);
            ViewData["T"] = winnars.First();*/
            List<string> winn = new List<string>();
            foreach (var item in items) 
            {
                winn.Add(item.ToString());           
            }
            return View(_repository.GetByID(id));
        }
        public ActionResult TestResult(int id)
        {
            return View((new ResultRepository()).GetByID(id));
        }
    }
}

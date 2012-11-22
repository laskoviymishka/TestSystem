using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Internet.Models;

namespace Internet.Controllers
{
    public class QuestionController : Controller
    {
        IRepository<Question> _repository;
        //
        // GET: /Question/
        public QuestionController() 
        {
            _repository = new QuestionRepository();
        }

        [Authorize(Roles = "Professor")]
        public ActionResult Index(int id)
        {
            ViewData["ANSWER_ID"] = id.ToString();
            return View(_repository.GetItemsWithParams(id));
        }

        //
        // GET: /Question/Details/5

        [Authorize(Roles = "Professor")]
        public ActionResult Details(int id)
        {
            return View(_repository.GetByID(id));
        }

        //
        // GET: /Question/Create

        [Authorize(Roles = "Professor")]
        public ActionResult Create(int id)
        {
            return View();
        } 

        //
        // POST: /Question/Create

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public ActionResult Create(int id,Question item)
        {
                _repository = new QuestionRepository();
                item.TestID = id;
                _repository.CreateItem(item);
                return RedirectToAction("Index/"+id);
        }
        
        //
        // GET: /Question/Edit/5

        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int id)
        {
            return View(_repository.GetByID(id));
        }

        //
        // POST: /Question/Edit/5

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int id, Question item)
        {
                _repository.UpdateItem(_repository.GetByID(id), item);
 
                return RedirectToAction("Index/" + _repository.GetByID(id).TestID);
        }

        //
        // GET: /Question/Delete/5

        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Question/Delete/5

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

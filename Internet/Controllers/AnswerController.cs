using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Internet.Models;

namespace Internet.Controllers
{
    public class AnswerController : Controller
    {
        //
        // GET: /Answer/index/5
        IRepository<Answer> _repository;

        public AnswerController() 
        {
            _repository = new AnswerRepository();
        }

        [Authorize(Roles = "Professor")]
        public ActionResult Index(int id)
        {
            ViewData["QUESTION_ID"] = id.ToString();
            IRepository<Question> _tempQuestion = new QuestionRepository();
            ViewData["TEST_ID"] = _tempQuestion.GetByID(id).TestID;
            return View(_repository.GetItemsWithParams(id));
        }

        //
        // GET: /Answer/Details/5

        [Authorize(Roles = "Professor")]
        public ActionResult Details(int id)
        {
            return View(_repository.GetByID(id));
        }

        //
        // GET: /Answer/Create

        [Authorize(Roles = "Professor")]
        public ActionResult Create(int id)
        {
            return View();
        } 

        //
        // POST: /Answer/Create

        [Authorize(Roles = "Professor")]
        [HttpPost]
        public ActionResult Create(int id,Answer item)
        {
            try
            {
                item.QuestionID = id;
                _repository.CreateItem(item);
                return RedirectToAction("Index/"+id);
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Answer/Edit/5

        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int id)
        {
            return View(_repository.GetByID(id));
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public ActionResult Edit(int id, Answer item)
        {
            
                _repository.UpdateItem(_repository.GetByID(id), item);
                return RedirectToAction("Index/" + _repository.GetByID(id).QuestionID);
            
        }

        //
        // GET: /Answer/Delete/5

        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Delete/5

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int id, Answer collection)
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

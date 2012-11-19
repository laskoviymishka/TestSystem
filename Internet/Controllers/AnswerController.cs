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
        IService<Answer> _service;
        public AnswerController() 
        {
            _service = new AnswerService();
        }

        public ActionResult Index(int id)
        {
            ViewData["QUESTION_ID"] = id.ToString();
            IService<Question> _tempQuestion = new QuestionService();
            ViewData["TEST_ID"] = _tempQuestion.GetByID(id).TestID;
            return View(_service.GetItemsWithParams(id));
        }

        //
        // GET: /Answer/Details/5

        public ActionResult Details(int id)
        {
            return View(_service.GetByID(id));
        }

        //
        // GET: /Answer/Create

        public ActionResult Create(int id)
        {
            return View();
        } 

        //
        // POST: /Answer/Create

        [HttpPost]
        public ActionResult Create(int id,Answer item)
        {
            try
            {
                item.QuestionID = id;
                _service.CreateItem(item);
                return RedirectToAction("Index/"+id);
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Answer/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_service.GetByID(id));
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Answer item)
        {
            
                _service.UpdateItem(_service.GetByID(id), item);
                return RedirectToAction("Index/" + _service.GetByID(id).QuestionID);
            
        }

        //
        // GET: /Answer/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Delete/5

        [HttpPost]
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

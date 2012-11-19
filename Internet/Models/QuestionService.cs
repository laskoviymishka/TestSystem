using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class QuestionService: IService<Question>
    {
        private List<Question> _questions;
        private TestEntities _testEntity;
        public QuestionService() 
        {
            _testEntity = new TestEntities();
            _questions = _testEntity.Questions.ToList<Question>();
            
        }
        public Question GetByID(int ID)
        {
            return _questions.Where(q => q.ID == ID).First();
        }
        public List<Question> GetQuestions() 
        {
            return _questions;
        }

        public void CreateItem(Question item)
        {
            item.ID = _testEntity.Questions.ToList<Question>().Last().ID;
            item.ID++;
            _testEntity.Questions.AddObject(item);
            _testEntity.SaveChanges();
        }

        public void DeleteItem(Question item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Question item, Question newItem)
        {
            Question q = _testEntity.Questions.Where(t => t.ID == item.ID).First();
            q.QuestionBody = newItem.QuestionBody;
            q.TestID = newItem.TestID;
            
            _testEntity.SaveChanges();
        }


        public List<Question> GetItems()
        {
            return _questions;
        }

        public List<Question> GetItemsWithParams(int param)
        {
            return _testEntity.Questions.Where(q => q.TestID == param).ToList<Question>();
        }

        public List<Question> GetItemsWithParams(string param)
        {
            throw new NotImplementedException();
        }
    }
}
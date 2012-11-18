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
        public QuestionService(Test QuestionTest, TestEntities testEntity) 
        {
            _questions = QuestionTest.Questions.ToList<Question>();
            _testEntity = testEntity;
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
            _testEntity.Questions.AddObject(item);
            _testEntity.SaveChanges();
        }

        public void DeleteItem(Question item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Question item, Question newItem)
        {
            Question q = this.GetByID(item.ID);
            q.QuestionBody = newItem.QuestionBody;
            q.TestID = newItem.TestID;
            q.Answers = newItem.Answers;
            _testEntity.SaveChanges();
        }


        public List<Question> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
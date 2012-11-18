using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class AnswerService:IService<Answer>
    {
        private List<Answer> _answers;
        private TestEntities _testEntity;
        public AnswerService(Question question, TestEntities testEntity)
        {
            _testEntity = testEntity;
            _answers = question.Answers.ToList<Answer>();
        }
        public Answer GetByID(int ID)
        {
            return _answers.Where<Answer>(a => a.ID == ID).First<Answer>();
        }

        public void CreateItem(Answer item)
        {
            _testEntity.Answers.AddObject(item);
            _testEntity.SaveChanges();
        }

        public void DeleteItem(Answer item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Answer item, Answer newItem)
        {
            Answer answer = _testEntity.Answers.Where<Answer>(a => a.ID == item.ID).First<Answer>();
            answer.IsRight = newItem.IsRight;
            answer.AnswerBody = newItem.AnswerBody;
        }


        public List<Answer> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
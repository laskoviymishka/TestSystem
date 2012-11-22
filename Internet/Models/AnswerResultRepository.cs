using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class AnswerResultRepository : IRepository<AnswerResult>
    {
        private List<AnswerResult> _results;
        private TestEntities _testEntity;
        public AnswerResultRepository()
        {
            _testEntity = EntityContextContainer.getEntity();
            _results = _testEntity.AnswerResults.ToList<AnswerResult>();
        }


        public AnswerResult GetByID(int ID)
        {
            return _results.Where(ar => ar.ID == ID).First<AnswerResult>();
        }

        public List<AnswerResult> GetItems()
        {
            return _results;
        }

        public List<AnswerResult> GetItemsWithParams(int param)
        {
            throw new NotImplementedException();
        }

        public List<AnswerResult> GetItemsWithParams(string param)
        {
            throw new NotImplementedException();
        }

        public void CreateItem(AnswerResult item)
        {
            _testEntity.AnswerResults.AddObject(item);
            _testEntity.SaveChanges();
        }

        public void DeleteItem(AnswerResult item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(AnswerResult item, AnswerResult newItem)
        {
            throw new NotImplementedException();
        }
    }
}
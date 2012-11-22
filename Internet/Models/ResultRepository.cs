using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class ResultRepository: IRepository<Result>
    {
        private List<Result> _results;
        private TestEntities _testEntity;
        public ResultRepository()
        {
            _testEntity = EntityContextContainer.getEntity();
            _results = _testEntity.Results.ToList<Result>();
        }
        public Result GetByID(int ID)
        {
            return _results.Where<Result>(r => r.ID == ID).FirstOrDefault<Result>();
        }

        public List<Result> GetItems()
        {
            
            return _results;
        }

        public List<Result> GetItemsWithParams(int param)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetItemsWithParams(string param)
        {
            throw new NotImplementedException();
        }

        public void CreateItem(Result item)
        {
            _testEntity.Results.AddObject(item);
            _testEntity.SaveChanges();
        }

        public void DeleteItem(Result item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Result item, Result newItem)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class TestRepository:IRepository<Test>
    {
        TestEntities _tests;
        public TestRepository() 
        {
            _tests = EntityContextContainer.getEntity();
            
        }
        #region Getters
        public Test GetByID(int ID)
        {
           return (Test)_tests.Tests.Where<Test>(t => t.ID == ID).FirstOrDefault<Test>();
        }

        public List<Test> GetByDifficult(int DifficultID)
        {
            return _tests.Tests.Where<Test>(t => t.DifficultyID == DifficultID).ToList<Test>();
        }

        public List<Test> GetByAuthor(string Author)
        {
            return _tests.Tests.Where<Test>(t => t.TestAuthor == Author).ToList<Test>();
        }

        public List<Test> GetByCategory(int CategoryID)
        {
            return _tests.Tests.Where<Test>(t => t.CategoryID == CategoryID).ToList<Test>();
        }
        #endregion


        #region Others
        public void CreateItem(Test item)
        {
            //item.ID = _tests.Tests.ToList().Last<Test>().ID + 1;
            //item.TestCategory = (TestCategory)_tests.TestCategories.Where<TestCategory>(c => c.ID == item.CategoryID).FirstOrDefault<TestCategory>();
           // item.Difficulty = (Difficulty)_tests.Difficulties.Where<Difficulty>(d => d.ID == item.DifficultyID).FirstOrDefault<Difficulty>();


            _tests.Tests.AddObject(item);
            _tests.SaveChanges();
        }
        public void DeleteItem(Test item)
        {
            _tests.Tests.DeleteObject(item);
            _tests.SaveChanges();
        }
        public void UpdateItem(Test item,Test newItem) 
        {
            Test test = this.GetByID(item.ID);
            test.TestName = newItem.TestName;
            test.TestDescription = newItem.TestDescription;
            test.CategoryID = newItem.CategoryID;
            test.DifficultyID = newItem.DifficultyID;
            _tests.SaveChanges();
        }
        #endregion


        public List<Test> GetItems()
        {
            return _tests.Tests.ToList<Test>();
        }


        public List<Test> GetItemsWithParams(int param)
        {
            throw new NotImplementedException();
        }

        public List<Test> GetItemsWithParams(string param)
        {
            throw new NotImplementedException();
        }
    }
}
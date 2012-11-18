using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public interface IService<T>
    {
        T GetByID(int ID);
        List<T> GetItems();

        void CreateItem(T item);
        void DeleteItem(T item);
        void UpdateItem(T item, T newItem);
    }
}
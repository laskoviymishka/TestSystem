using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class EntityContextContainer
    {

        public static TestEntities getEntity() 
        {
            return new TestEntities();
        }
    }
}
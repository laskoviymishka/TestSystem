using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet.Models
{
    public class CheckListModel
    {
        public ICollection<string> CheckBoxTestItems { get; set; }
        public string RadioButtonTestItems { get; set; }
    }
}
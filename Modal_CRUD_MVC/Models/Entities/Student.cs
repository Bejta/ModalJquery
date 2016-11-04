using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modal_CRUD_MVC.Models.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
using Modal_CRUD_MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Modal_CRUD_MVC.Models
{
    public class StudentDBContext : DbContext
    {
        public DbSet<Student> Students
        {
            get;
            set;
        }
    }
}
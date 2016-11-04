using Modal_CRUD_MVC.Models;
using Modal_CRUD_MVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modal_CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        StudentDBContext db = new StudentDBContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpGet]
        public ActionResult AddEditRecord (int? id)
        {
            //Check if Ajax
            if (Request.IsAjaxRequest())
            {
                if (id != null)
                {
                    ViewBag.IsUpdate = true;
                    Student student = db.Students.Where(m => m.StudentID == id).FirstOrDefault();

                    return PartialView("_StudentData", student);

                }
                ViewBag.IsUpdate = false;
                return PartialView("_StudentData");
            }
            else
            {
                if( id!= null)
                {
                    ViewBag.IsUpdate = true;
                    Student student = db.Students.Where(m => m.StudentID == id).FirstOrDefault();

                    return PartialView("StudentData", student);

                }
                ViewBag.IsUpdate = false;
                return View("StudentData");

            }
        }
        [HttpPost]
        public ActionResult AddEditRecord (Student student, string cmd)
        {
            if (ModelState.IsValid)
            {
                if (cmd == "Save")
                {
                    try
                    {
                        db.Students.Add(student);
                        db.SaveChanges();
                        return RedirectToAction ("Index");
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        Student stud = db.Students.Where(m => m.StudentID == student.StudentID).FirstOrDefault();

                        if (stud != null)
                        {
                            stud.Name = student.Name;
                            stud.Age = student.Age;
                            stud.State = student.State;
                            stud.Country = student.Country;
                            db.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                    }
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_StudentData", student);
            }
            else
            {
                return View("StudentData", student);
            }
        }

        public ActionResult DeleteRecord(int id)
        {
            Student student = db.Students.Where(m => m.StudentID == id).FirstOrDefault();

            if (student != null)
            {
                try
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
                catch
                {

                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student student = db.Students.Where(m => m.StudentID == id).FirstOrDefault();

            if (student != null)
            {
                if (!Request.IsAjaxRequest())
                {
                    return PartialView("_StudentDetails", student);
                }
                else
                {
                    return View("StudentDetails", student);
                }
            }

            return View("Index");
        }
    }
}
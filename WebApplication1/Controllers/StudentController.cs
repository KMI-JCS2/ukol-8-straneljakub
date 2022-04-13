using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : BaseController
    {
        public ActionResult All()
        {
            List<Student> students = Ctx.Students.ToList();
            ViewBag.Blekeke = "tralala";
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == id);
            if (s!=null)
            {
                return View(s);
            } else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        [HttpPost]
        public ActionResult Edit(Student studentEdited)
        {
            Student s = Ctx.Students.FirstOrDefault(p => p.Id == studentEdited.Id);
            if (s != null)
            {
                s.Name = studentEdited.Name;
                s.Surname = studentEdited.Surname;
                s.Rocnik = studentEdited.Rocnik;
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }

        [HttpGet]
        public ActionResult Add()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student s)
        {
            if (s != null)
            {
                Ctx.Students.Add(s);
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Student is invalid");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student deleted = Ctx.Students.FirstOrDefault(s => s.Id == id);
            Ctx.Students.Remove(deleted);
            Ctx.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Student student = Ctx.Students.FirstOrDefault(s => s.Id == id);
            
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return new HttpNotFoundResult("Student not found");
            }
        }
    }
}
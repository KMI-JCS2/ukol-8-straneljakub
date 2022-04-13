using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubjectController : BaseController
    {
        public ActionResult All()
        {
            List<Subject> subjects = Ctx.Subjects.ToList();
            return View(subjects);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == id);
            if (s != null)
            {
                return View(s);
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }

        [HttpPost]
        public ActionResult Edit(Subject subjectEdited)
        {
            Subject s = Ctx.Subjects.FirstOrDefault(p => p.Id == subjectEdited.Id);
            if (s != null)
            {
                s.Abbrev = subjectEdited.Abbrev;
                s.Department = subjectEdited.Department;
                s.Name = subjectEdited.Name;
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
        public ActionResult Add(Subject s)
        {
            if (s != null)
            {
                Ctx.Subjects.Add(s);
                Ctx.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return new HttpNotFoundResult("Subject is invalid");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Subject deleted = Ctx.Subjects.FirstOrDefault(s => s.Id == id);
            Ctx.Subjects.Remove(deleted);
            Ctx.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Subject subject = Ctx.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject != null)
            {
                return View(subject);
            }
            else
            {
                return new HttpNotFoundResult("Subject not found");
            }
        }
    }
}
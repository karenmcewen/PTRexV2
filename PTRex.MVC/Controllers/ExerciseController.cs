using PTRex.MVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PTRex.MVC.Controllers
{
    public class ExerciseController : Controller
    {
        private PTRexEntities db = new PTRexEntities();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";

            var exercises = from s in db.Exercises
                            select s;

            switch (sortOrder)
            {
                default:
                    exercises = exercises.OrderBy(s => s.Name);
                    break;
            }

            return View(exercises.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exercise exercise = db.Exercises.Find(id);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
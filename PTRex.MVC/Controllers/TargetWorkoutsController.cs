using PTRex.MVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace PTRex.MVC.Controllers
{
    public class TargetWorkoutsController : Controller
    {
        private PTRexEntities db = new PTRexEntities();

        public ActionResult Index()
        {
            var targetWorkouts = db.TargetWorkouts.Include(t => t.Exercise).Include(t => t.UserProfile);
            return View(targetWorkouts.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            ViewBag.UserProfileID = new SelectList(db.UserProfiles, "ID", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TargetWorkout targetWorkout)
        {
            if (ModelState.IsValid)
            {
                db.TargetWorkouts.Add(targetWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", targetWorkout.ExerciseID);
            ViewBag.UserProfileID = new SelectList(db.UserProfiles, "ID", "UserName", targetWorkout.UserProfileID);
            return View(targetWorkout);
        }

        public ActionResult CreatePage2()
        {
            var targetWorkouts = db.TargetWorkouts.Include(t => t.Exercise).Include(t => t.UserProfile);
            return View(targetWorkouts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TargetWorkout targetWorkout = db.TargetWorkouts.Find(id);

            if (targetWorkout == null)
                return HttpNotFound();
            
            return View(targetWorkout);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetWorkout targetWorkout = db.TargetWorkouts.Find(id);
            if (targetWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", targetWorkout.ExerciseID);
            ViewBag.UserProfileID = new SelectList(db.UserProfiles, "ID", "UserName", targetWorkout.UserProfileID);
            return View(targetWorkout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TargetWorkout targetWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targetWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", targetWorkout.ExerciseID);
            ViewBag.UserProfileID = new SelectList(db.UserProfiles, "ID", "UserName", targetWorkout.UserProfileID);
            return View(targetWorkout);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetWorkout targetWorkout = db.TargetWorkouts.Find(id);
            if (targetWorkout == null)
            {
                return HttpNotFound();
            }
            return View(targetWorkout);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TargetWorkout targetWorkout = db.TargetWorkouts.Find(id);
            db.TargetWorkouts.Remove(targetWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using PTRex.MVC.Models;
using PTRex.MVC.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PTRex.MVC.Controllers
{
    public class ActualWorkoutsController : Controller
    {
        private PTRexEntities db = new PTRexEntities();

        // GET: ActualWorkouts
        public ActionResult Index()
        {
            var actualWorkouts = db.ActualWorkouts.Include(a => a.PainLevel).Include(a => a.TargetWorkout).Include(a => a.TimeOfDay);
            return View(actualWorkouts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ActualWorkout actualWorkout = db.ActualWorkouts.Find(id);

            if (actualWorkout == null)
            {
                return HttpNotFound();
            }

            return View(actualWorkout);
        }

        public ActionResult Create()
        {
            WorkoutViewModel model = new WorkoutViewModel();

            ViewBag.TargetWorkouts = (from tw in db.TargetWorkouts
                                      select tw).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create2(WorkoutViewModel model)
        {
            model.TargetWorkout = db.TargetWorkouts.Where(tw => tw.ID == model.SelectedTargetWorkoutId).FirstOrDefault();

            ViewBag.PainLevels = (from pl in db.PainLevels
                                  select pl).ToList();

            ViewBag.TimesOfDay = (from tod in db.TimeOfDays
                                  select tod).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveActualWorkout(WorkoutViewModel model)
        {
            model.ActualWorkout.TargetWorkoutID = model.TargetWorkout.ID;

            if (ModelState.IsValid)
            {
                db.ActualWorkouts.Add(model.ActualWorkout);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.PainLevels = (from pl in db.PainLevels
                                  select pl).ToList();

            ViewBag.TargetWorkoutID = new SelectList(db.TargetWorkouts, "ID", "TargetNotes", model.ActualWorkout.TargetWorkoutID);
            ViewBag.TimeOfDayID = new SelectList(db.TimeOfDays, "ID", "TimeOfDay1", model.ActualWorkout.TimeOfDayID);

            return View(model.ActualWorkout);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ActualWorkout actualWorkout = db.ActualWorkouts.Find(id);

            if (actualWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.PainLevelID = new SelectList(db.PainLevels, "ID", "PainLevelName", actualWorkout.PainLevelID);
            ViewBag.TargetWorkoutID = new SelectList(db.TargetWorkouts, "ID", "TargetNumSets", "TargetNumReps", actualWorkout.TargetWorkoutID);
            ViewBag.TimeOfDayID = new SelectList(db.TimeOfDays, "ID", "TimeOfDay1", actualWorkout.TimeOfDayID);
            return View(actualWorkout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActualWorkout actualWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PainLevelID = new SelectList(db.PainLevels, "ID", "PainLevelName", actualWorkout.PainLevelID);
            ViewBag.TargetWorkoutID = new SelectList(db.TargetWorkouts, "ID", "TargetNumSets", "TargetNumReps", actualWorkout.TargetWorkoutID);
            ViewBag.TimeOfDayID = new SelectList(db.TimeOfDays, "ID", "TimeOfDay1", actualWorkout.TimeOfDayID);

            return View(actualWorkout);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualWorkout actualWorkout = db.ActualWorkouts.Find(id);
            if (actualWorkout == null)
            {
                return HttpNotFound();
            }
            return View(actualWorkout);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActualWorkout actualWorkout = db.ActualWorkouts.Find(id);
            db.ActualWorkouts.Remove(actualWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
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
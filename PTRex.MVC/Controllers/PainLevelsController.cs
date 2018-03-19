using PTRex.MVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PTRex.MVC.Controllers
{
    public class PainLevelsController : Controller
    {
        private PTRexEntities db = new PTRexEntities();

        public ActionResult Index()
        {
            return View(db.PainLevels.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PainLevel painLevel)
        {
            if (ModelState.IsValid)
            {
                db.PainLevels.Add(painLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(painLevel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PainLevel painLevel = db.PainLevels.Find(id);

            if (painLevel == null)
            {
                return HttpNotFound();
            }

            return View(painLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PainLevel painLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(painLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(painLevel);
        }
    }
}
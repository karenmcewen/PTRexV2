using PTRex.MVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PTRex.MVC.Controllers
{
    public class UserProfilesController : Controller
    {
        private PTRexEntities db = new PTRexEntities();

        public ActionResult Index()
        {
            var userProfiles = db.UserProfiles.Include(u => u.AspNetUser);
            return View(userProfiles.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.UserName = new SelectList(db.AspNetUsers, "Id", "Email", userProfile.UserName);
            return View(userProfile);
        }

        public ActionResult Details()
        {
            UserProfile userProfile = db.UserProfiles.FirstOrDefault(p => p.Email == User.Identity.Name);

            if (userProfile == null)
                return RedirectToAction("Create");

            return View(userProfile);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = new SelectList(db.AspNetUsers, "Id", "Email", userProfile.UserName);
            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.AspNetUsers, "Id", "Email", userProfile.UserName);
            return View(userProfile);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            UserProfile userProfile = db.UserProfiles.Find(id);

            if (userProfile == null)
                return HttpNotFound();
            
            return View(userProfile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
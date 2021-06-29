using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using twitterapp.Models;

namespace twitterapp.Controllers
{
    [Authorize]
    public class newpostsController : Controller
    {
        private Model1 db = new Model1();

        // GET: newposts
        public ActionResult Index()
        {
            int userid = 0;
            if (Session["userId"] != null)
            {
                userid = (int)Session["userId"];
                var newposts = db.newposts.Include(n => n.user).Where(x => x.UserId == userid);
                return View(newposts.ToList());
            }
            else
            {
                return RedirectToAction("LogOut", "Home");
            }
            
            
        }

        // GET: newposts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newpost newpost = db.newposts.Find(id);
            if (newpost == null)
            {
                return HttpNotFound();
            }
            return View(newpost);
        }

        // GET: newposts/Create
        public ActionResult Create()
        {
            List<user> u = new List<user>();
            string email = " ";
            if (Session["user"] != null)
            {
                email = Session["user"].ToString();
            }
            var use = db.users.SingleOrDefault(x => x.Email == email);
            u.Add(use);
            ViewBag.UserId = new SelectList(u, "Id", "Name");
            //ViewBag.UserId = new SelectList(db.users, "Id", "Name");
            return View();
        }

        // POST: newposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Post,UserId")] newpost newpost)
        {
            if (ModelState.IsValid)
            {
                db.newposts.Add(newpost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<user> u = new List<user>();
            string email = " ";
            if (Session["user"] != null)
            {
                email = Session["user"].ToString();
            }
            var use = db.users.SingleOrDefault(x => x.Email == email);
            u.Add(use);
            ViewBag.UserId = new SelectList(u, "Id", "Name", newpost.UserId);

           // ViewBag.UserId = new SelectList(db.users, "Id", "Name", newpost.UserId);
            return View(newpost);
        }

        // GET: newposts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newpost newpost = db.newposts.Find(id);
            if (newpost == null)
            {
                return HttpNotFound();
            }
            List<user> u = new List<user>();
            string email = " ";
            if (Session["user"] != null)
            {
                email = Session["user"].ToString();
            }
            var use = db.users.SingleOrDefault(x => x.Email == email);
            u.Add(use);
            ViewBag.UserId = new SelectList(u, "Id", "Name", newpost.UserId);
            return View(newpost);
        }

        // POST: newposts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Post,UserId")] newpost newpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<user> u = new List<user>();
            string email = " ";
            if(Session["user"]!=null)
            {
                email = Session["user"].ToString();
            }
            var use = db.users.SingleOrDefault(x => x.Email == email);
            u.Add(use);
            ViewBag.UserId = new SelectList(u, "Id", "Name", newpost.UserId);
            return View(newpost);
        }

        // GET: newposts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newpost newpost = db.newposts.Find(id);
            if (newpost == null)
            {
                return HttpNotFound();
            }
            return View(newpost);
        }

        // POST: newposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newpost newpost = db.newposts.Find(id);
            db.newposts.Remove(newpost);
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

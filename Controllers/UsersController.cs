using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WonderBox.CustomFilters;
using WonderBox.Models;
using Microsoft.AspNet.Identity;


namespace WonderBox.Controllers
{
    public class UsersController : Controller
    {
        private MasterBoxDBContext db = new MasterBoxDBContext();

        // GET: Users
        public ActionResult Index()
        {
            var UserID = User.Identity.GetUserId();
            var UserInfo = db.Users.Where(userid => userid.UserID == UserID);
            return View(UserInfo.ToList());
        }

        [AuthLog(Roles = "Admin")]
        public ActionResult AdminView()
        {
            return View(db.Users.ToList());
        }

        public ActionResult BuyMonthly()
        {
            var SubsName = "Mystery Box";
            var SubscriptionName = db.Subcriptions.Where(sub => sub.SubName == SubsName).Single();

            var UserID = User.Identity.GetUserId();
            var UserInfo = db.Users.Where(userid => userid.UserID == UserID).Single();

            UserInfo.AmountOwed += SubscriptionName.MonthlyPrice;

            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult BuyYearly()
        {
            var SubsName = "Mystery Box";
            var SubscriptionName = db.Subcriptions.Where(sub => sub.SubName == SubsName).Single();

            var UserID = User.Identity.GetUserId();
            var UserInfo = db.Users.Where(userid => userid.UserID == UserID).Single();

            UserInfo.AmountOwed += SubscriptionName.YearlyPrice;
     
            db.SaveChanges();
            return Redirect("Index");
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,City,State,Zipcode,Age,Gender")] Users users)
        {

            if (ModelState.IsValid)
            {
                users.UserID = User.Identity.GetUserId();
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,City,State,Zipcode,Age,Gender")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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

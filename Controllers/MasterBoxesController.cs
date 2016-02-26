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

namespace WonderBox.Controllers
{
    
    public class MasterBoxesController : Controller
    {
        private MasterBoxDBContext db = new MasterBoxDBContext();

        // GET: MasterBoxes
        [AuthLog(Roles ="Admin")]
        public ActionResult Index()
        {
            return View(db.Boxes.ToList());
        }

        // GET: MasterBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterBox masterBox = db.Boxes.Find(id);
            if (masterBox == null)
            {
                return HttpNotFound();
            }
            return View(masterBox);
        }

        // GET: MasterBoxes/Create
        [AuthLog(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Users ="Admin")]
        public ActionResult Create([Bind(Include = "BoxId,BoxName,Price")] MasterBox masterBox)
        {
            if (ModelState.IsValid)
            {
                db.Boxes.Add(masterBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterBox);
        }

        // GET: MasterBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterBox masterBox = db.Boxes.Find(id);
            if (masterBox == null)
            {
                return HttpNotFound();
            }
            return View(masterBox);
        }

        // POST: MasterBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoxId,BoxName,Price")] MasterBox masterBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterBox);
        }

        // GET: MasterBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterBox masterBox = db.Boxes.Find(id);
            if (masterBox == null)
            {
                return HttpNotFound();
            }
            return View(masterBox);
        }

        // POST: MasterBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterBox masterBox = db.Boxes.Find(id);
            db.Boxes.Remove(masterBox);
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

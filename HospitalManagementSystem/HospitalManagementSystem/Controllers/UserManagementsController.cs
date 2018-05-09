using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class UserManagementsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: UserManagements
        public ActionResult Index()
        {
            var userManagements = db.UserManagements.Include(u => u.UserType);
            return View(userManagements.ToList());
        }

        // GET: UserManagements/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManagement userManagement = db.UserManagements.Find(id);
            if (userManagement == null)
            {
                return HttpNotFound();
            }
            return View(userManagement);
        }

        // GET: UserManagements/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description");
            return View();
        }

        // POST: UserManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,UserTypeId")] UserManagement userManagement)
        {
            if (ModelState.IsValid)
            {
                userManagement.Id = Guid.NewGuid();
                db.UserManagements.Add(userManagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", userManagement.UserTypeId);
            return View(userManagement);
        }

        // GET: UserManagements/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManagement userManagement = db.UserManagements.Find(id);
            if (userManagement == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", userManagement.UserTypeId);
            return View(userManagement);
        }

        // POST: UserManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,UserTypeId")] UserManagement userManagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userManagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", userManagement.UserTypeId);
            return View(userManagement);
        }

        // GET: UserManagements/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManagement userManagement = db.UserManagements.Find(id);
            if (userManagement == null)
            {
                return HttpNotFound();
            }
            return View(userManagement);
        }

        // POST: UserManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserManagement userManagement = db.UserManagements.Find(id);
            db.UserManagements.Remove(userManagement);
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

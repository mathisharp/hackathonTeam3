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
    public class PatientDetailsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PatientDetails
        public ActionResult Index()
        {
            var patientDetails = db.PatientDetails.Include(p => p.UserType);
            return View(patientDetails.ToList());
        }

        // GET: PatientDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDetails patientDetails = db.PatientDetails.Find(id);
            if (patientDetails == null)
            {
                return HttpNotFound();
            }
            return View(patientDetails);
        }

        // GET: PatientDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description");
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Gender,UserTypeId")] PatientDetails patientDetails)
        {
            if (ModelState.IsValid)
            {
                patientDetails.Id = Guid.NewGuid();
                db.PatientDetails.Add(patientDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", patientDetails.UserTypeId);
            return View(patientDetails);
        }

        // GET: PatientDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDetails patientDetails = db.PatientDetails.Find(id);
            if (patientDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", patientDetails.UserTypeId);
            return View(patientDetails);
        }

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Gender,UserTypeId")] PatientDetails patientDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Description", patientDetails.UserTypeId);
            return View(patientDetails);
        }

        // GET: PatientDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDetails patientDetails = db.PatientDetails.Find(id);
            if (patientDetails == null)
            {
                return HttpNotFound();
            }
            return View(patientDetails);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PatientDetails patientDetails = db.PatientDetails.Find(id);
            db.PatientDetails.Remove(patientDetails);
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

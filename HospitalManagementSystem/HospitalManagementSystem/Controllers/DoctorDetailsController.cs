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
    public class DoctorDetailsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DoctorDetails
        public ActionResult Index()
        {
            var doctorDetails = db.DoctorDetails.Include(d => d.Speciality);
            return View(doctorDetails.ToList());
        }

        // GET: DoctorDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetails doctorDetails = db.DoctorDetails.Find(id);
            if (doctorDetails == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetails);
        }

        // GET: DoctorDetails/Create
        public ActionResult Create()
        {
            ViewBag.SpecialityId = new SelectList(db.Specialitys, "Id", "Description");
            return View();
        }

        // POST: DoctorDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmailId,SpecialityId")] DoctorDetails doctorDetails)
        {
            if (ModelState.IsValid)
            {
                doctorDetails.Id = Guid.NewGuid();
                db.DoctorDetails.Add(doctorDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecialityId = new SelectList(db.Specialitys, "Id", "Description", doctorDetails.SpecialityId);
            return View(doctorDetails);
        }

        // GET: DoctorDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetails doctorDetails = db.DoctorDetails.Find(id);
            if (doctorDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecialityId = new SelectList(db.Specialitys, "Id", "Description", doctorDetails.SpecialityId);
            return View(doctorDetails);
        }

        // POST: DoctorDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmailId,SpecialityId")] DoctorDetails doctorDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecialityId = new SelectList(db.Specialitys, "Id", "Description", doctorDetails.SpecialityId);
            return View(doctorDetails);
        }

        // GET: DoctorDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetails doctorDetails = db.DoctorDetails.Find(id);
            if (doctorDetails == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetails);
        }

        // POST: DoctorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DoctorDetails doctorDetails = db.DoctorDetails.Find(id);
            db.DoctorDetails.Remove(doctorDetails);
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

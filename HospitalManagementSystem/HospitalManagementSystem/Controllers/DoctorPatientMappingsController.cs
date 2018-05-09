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
    public class DoctorPatientMappingsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DoctorPatientMappings
        public ActionResult Index()
        {
            var doctorPatientMappings = db.DoctorPatientMappings.Include(d => d.DoctorDetails).Include(d => d.PatientDetails);
            return View(doctorPatientMappings.ToList());
        }

        // GET: DoctorPatientMappings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorPatientMapping doctorPatientMapping = db.DoctorPatientMappings.Find(id);
            if (doctorPatientMapping == null)
            {
                return HttpNotFound();
            }
            return View(doctorPatientMapping);
        }

        // GET: DoctorPatientMappings/Create
        public ActionResult Create()
        {
            ViewBag.DoctorDetailsId = new SelectList(db.DoctorDetails, "Id", "Name");
            ViewBag.PatientDetailsId = new SelectList(db.PatientDetails, "Id", "Name");
            return View();
        }

        // POST: DoctorPatientMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientDetailsId,DoctorDetailsId,FromDateTime,ToDateTime,IsCancelled")] DoctorPatientMapping doctorPatientMapping)
        {
            if (ModelState.IsValid)
            {
                doctorPatientMapping.Id = Guid.NewGuid();
                db.DoctorPatientMappings.Add(doctorPatientMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorDetailsId = new SelectList(db.DoctorDetails, "Id", "Name", doctorPatientMapping.DoctorDetailsId);
            ViewBag.PatientDetailsId = new SelectList(db.PatientDetails, "Id", "Name", doctorPatientMapping.PatientDetailsId);
            return View(doctorPatientMapping);
        }

        // GET: DoctorPatientMappings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorPatientMapping doctorPatientMapping = db.DoctorPatientMappings.Find(id);
            if (doctorPatientMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorDetailsId = new SelectList(db.DoctorDetails, "Id", "Name", doctorPatientMapping.DoctorDetailsId);
            ViewBag.PatientDetailsId = new SelectList(db.PatientDetails, "Id", "Name", doctorPatientMapping.PatientDetailsId);
            return View(doctorPatientMapping);
        }

        // POST: DoctorPatientMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientDetailsId,DoctorDetailsId,FromDateTime,ToDateTime,IsCancelled")] DoctorPatientMapping doctorPatientMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorPatientMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorDetailsId = new SelectList(db.DoctorDetails, "Id", "Name", doctorPatientMapping.DoctorDetailsId);
            ViewBag.PatientDetailsId = new SelectList(db.PatientDetails, "Id", "Name", doctorPatientMapping.PatientDetailsId);
            return View(doctorPatientMapping);
        }

        // GET: DoctorPatientMappings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorPatientMapping doctorPatientMapping = db.DoctorPatientMappings.Find(id);
            if (doctorPatientMapping == null)
            {
                return HttpNotFound();
            }
            return View(doctorPatientMapping);
        }

        // POST: DoctorPatientMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DoctorPatientMapping doctorPatientMapping = db.DoctorPatientMappings.Find(id);
            db.DoctorPatientMappings.Remove(doctorPatientMapping);
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

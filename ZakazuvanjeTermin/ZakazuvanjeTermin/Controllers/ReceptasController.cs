using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZakazuvanjeTermin.Models;

namespace ZakazuvanjeTermin.Controllers
{
    public class ReceptasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Receptas
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            return View(db.Receptas.ToList());
        }

        // GET: Receptas/Details/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepta recepta = db.Receptas.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // GET: Receptas/Create
        [Authorize(Roles = "Doctor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receptas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Create([Bind(Include = "Id,Name,miligrami,dozvolenaDoza")] Recepta recepta)
        {
            if (ModelState.IsValid)
            {
                db.Receptas.Add(recepta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recepta);
        }

        // GET: Receptas/Edit/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepta recepta = db.Receptas.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Receptas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit([Bind(Include = "Id,Name,miligrami,dozvolenaDoza")] Recepta recepta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recepta);
        }

        // GET: Receptas/Delete/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepta recepta = db.Receptas.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Receptas/Delete/5
        [Authorize(Roles = "Doctor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recepta recepta = db.Receptas.Find(id);
            db.Receptas.Remove(recepta);
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

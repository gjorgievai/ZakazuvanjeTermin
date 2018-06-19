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
    public class PacientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pacients
        public ActionResult Index()
        {
            return View(db.Pacients.ToList());
        }
        [Authorize(Roles = "Doctor")]

        public ActionResult AddPacientRecept(int id)
        {
            AddPacientRecepta model = new AddPacientRecepta();
            model.selectedPacient = id;
            model.recepti = db.Receptas.ToList();
            var pacient = db.Pacients.Find(id);
            ViewBag.pacientName = db.Pacients.Find(id).FirstName + " " + db.Pacients.Find(id).LastName;


            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult AddPacientRecept(AddPacientRecepta model)
        {
            var pacient = db.Pacients.Find(model.selectedPacient);
            var recepta = db.Receptas.Find(model.selectedRecepta);
            pacient.recepti.Add(recepta);
            db.SaveChanges();

            return RedirectToAction("Index", db.Receptas.ToList());
        }

        // GET: Pacients/Details/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // GET: Pacients/Create
        [Authorize(Roles = "Doctor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EMBG")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Pacients.Add(pacient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacient);
        }

        // GET: Pacients/Edit/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EMBG")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Doctor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacient pacient = db.Pacients.Find(id);
            db.Pacients.Remove(pacient);
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

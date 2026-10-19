using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using P1_ExamenProgreso.Models;

namespace P1_ExamenProgreso.Controllers
{
    public class CaballeroesController : Controller
    {
        private ZodiacoDbContext db = new ZodiacoDbContext();

        // GET: Caballeroes
        public ActionResult Index()
        {
            return View(db.caballeros.ToList());
        }

        // GET: Caballeroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caballero caballero = db.caballeros.Find(id);
            if (caballero == null)
            {
                return HttpNotFound();
            }
            return View(caballero);
        }

        // GET: Caballeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caballeroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,constelacion,nivelPoder,elemento")] Caballero caballero)
        {
            if (ModelState.IsValid)
            {
                db.caballeros.Add(caballero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caballero);
        }

        // GET: Caballeroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caballero caballero = db.caballeros.Find(id);
            if (caballero == null)
            {
                return HttpNotFound();
            }
            return View(caballero);
        }

        // POST: Caballeroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,constelacion,nivelPoder,elemento")] Caballero caballero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caballero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caballero);
        }

        // GET: Caballeroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caballero caballero = db.caballeros.Find(id);
            if (caballero == null)
            {
                return HttpNotFound();
            }
            return View(caballero);
        }

        // POST: Caballeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caballero caballero = db.caballeros.Find(id);
            db.caballeros.Remove(caballero);
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

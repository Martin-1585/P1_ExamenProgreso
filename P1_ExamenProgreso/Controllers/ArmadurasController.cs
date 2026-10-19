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
    public class ArmadurasController : Controller
    {
        private ZodiacoDbContext db = new ZodiacoDbContext();

        // GET: Armaduras
        public ActionResult Index()
        {
            var armaduras = db.armaduras.Include(a => a.caballero);
            return View(armaduras.ToList());
        }

        // GET: Armaduras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // GET: Armaduras/Create
        public ActionResult Create()
        {
            ViewBag.caballeroId = new SelectList(db.caballeros, "id", "nombre");
            return View();
        }

        // POST: Armaduras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombreArmadura,tipo,resistencia,caballeroId")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                db.armaduras.Add(armadura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.caballeroId = new SelectList(db.caballeros, "id", "nombre", armadura.caballeroId);
            return View(armadura);
        }

        // GET: Armaduras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            ViewBag.caballeroId = new SelectList(db.caballeros, "id", "nombre", armadura.caballeroId);
            return View(armadura);
        }

        // POST: Armaduras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombreArmadura,tipo,resistencia,caballeroId")] Armadura armadura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armadura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.caballeroId = new SelectList(db.caballeros, "id", "nombre", armadura.caballeroId);
            return View(armadura);
        }

        // GET: Armaduras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armadura armadura = db.armaduras.Find(id);
            if (armadura == null)
            {
                return HttpNotFound();
            }
            return View(armadura);
        }

        // POST: Armaduras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armadura armadura = db.armaduras.Find(id);
            db.armaduras.Remove(armadura);
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

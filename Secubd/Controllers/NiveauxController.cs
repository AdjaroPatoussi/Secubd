using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Secubd.Models;

namespace Secubd.Controllers
{
    public class NiveauxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Niveaux
        public ActionResult Index()
        {
            var niveaux = db.Niveaux.Include(n => n.Parcour);
            return View(niveaux.ToList());
        }

        // GET: Niveaux/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // GET: Niveaux/Create
        public ActionResult Create()
        {
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar");
            return View();
        }

        // POST: Niveaux/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeNiv,libelleNiv,nbreModule,codePar")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Niveaux.Add(niveau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", niveau.codePar);
            return View(niveau);
        }

        // GET: Niveaux/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", niveau.codePar);
            return View(niveau);
        }

        // POST: Niveaux/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeNiv,libelleNiv,nbreModule,codePar")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niveau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", niveau.codePar);
            return View(niveau);
        }

        // GET: Niveaux/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niveau niveau = db.Niveaux.Find(id);
            if (niveau == null)
            {
                return HttpNotFound();
            }
            return View(niveau);
        }

        // POST: Niveaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Niveau niveau = db.Niveaux.Find(id);
            db.Niveaux.Remove(niveau);
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

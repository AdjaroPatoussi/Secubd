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
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(c => c.Niveau);
            return View(classes.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv");
            return View();
        }

        // POST: Classes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeClass,codeNiv,libelleClass,capacite")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(classe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", classe.codeNiv);
            return View(classe);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", classe.codeNiv);
            return View(classe);
        }

        // POST: Classes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeClass,codeNiv,libelleClass,capacite")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", classe.codeNiv);
            return View(classe);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classes.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Classe classe = db.Classes.Find(id);
            db.Classes.Remove(classe);
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

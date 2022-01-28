using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Secubd.Models;
using Secubd.vu;

namespace Secubd.Controllers
{
    public class ConsEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConsEnseignants
        public ActionResult Index()
        {
            return View(db.ConsEnseignant.ToList());
        }

        // GET: ConsEnseignants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignant consEnseignant = db.ConsEnseignant.Find(id);
            if (consEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignant);
        }

        // GET: ConsEnseignants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsEnseignants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] ConsEnseignant consEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.ConsEnseignant.Add(consEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consEnseignant);
        }

        // GET: ConsEnseignants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignant consEnseignant = db.ConsEnseignant.Find(id);
            if (consEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignant);
        }

        // POST: ConsEnseignants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] ConsEnseignant consEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consEnseignant);
        }

        // GET: ConsEnseignants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignant consEnseignant = db.ConsEnseignant.Find(id);
            if (consEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignant);
        }

        // POST: ConsEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ConsEnseignant consEnseignant = db.ConsEnseignant.Find(id);
            db.ConsEnseignant.Remove(consEnseignant);
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

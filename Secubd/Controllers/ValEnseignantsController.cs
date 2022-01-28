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
    [Authorize]
    public class ValEnseignantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValEnseignants
        public ActionResult Index()
        {
            return View(db.ValEnseignant.Where(v=>v.logEns== User.Identity.Name).ToList());
        }

        // GET: ValEnseignants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValEnseignant valEnseignant = db.ValEnseignant.Find(id);
            if (valEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(valEnseignant);
        }

        // GET: ValEnseignants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValEnseignants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,codeEns,nomETudiant,codePar,nomMod,note,nomEnseignant,libelleEval")] ValEnseignant valEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.ValEnseignant.Add(valEnseignant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valEnseignant);
        }

        // GET: ValEnseignants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValEnseignant valEnseignant = db.ValEnseignant.Find(id);
            if (valEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(valEnseignant);
        }

        // POST: ValEnseignants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,codeEns,nomETudiant,codePar,nomMod,note,nomEnseignant,libelleEval")] ValEnseignant valEnseignant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valEnseignant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valEnseignant);
        }

        // GET: ValEnseignants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValEnseignant valEnseignant = db.ValEnseignant.Find(id);
            if (valEnseignant == null)
            {
                return HttpNotFound();
            }
            return View(valEnseignant);
        }

        // POST: ValEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ValEnseignant valEnseignant = db.ValEnseignant.Find(id);
            db.ValEnseignant.Remove(valEnseignant);
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

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
    public class ConsEnseignantAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConsEnseignantAns
        public ActionResult Index()
        {
            return View(db.ConsEnseignantAn.ToList());
        }

        // GET: ConsEnseignantAns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignantAn consEnseignantAn = db.ConsEnseignantAn.Find(id);
            if (consEnseignantAn == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignantAn);
        }

        // GET: ConsEnseignantAns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsEnseignantAns/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,codeEns,nomETudiant,codePar,nomMod,note,nomEnseignant,libelleEval,logEns")] ConsEnseignantAn consEnseignantAn)
        {
            if (ModelState.IsValid)
            {
                db.ConsEnseignantAn.Add(consEnseignantAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consEnseignantAn);
        }

        // GET: ConsEnseignantAns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignantAn consEnseignantAn = db.ConsEnseignantAn.Find(id);
            if (consEnseignantAn == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignantAn);
        }

        // POST: ConsEnseignantAns/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,codeEns,nomETudiant,codePar,nomMod,note,nomEnseignant,libelleEval,logEns")] ConsEnseignantAn consEnseignantAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consEnseignantAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consEnseignantAn);
        }

        // GET: ConsEnseignantAns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsEnseignantAn consEnseignantAn = db.ConsEnseignantAn.Find(id);
            if (consEnseignantAn == null)
            {
                return HttpNotFound();
            }
            return View(consEnseignantAn);
        }

        // POST: ConsEnseignantAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ConsEnseignantAn consEnseignantAn = db.ConsEnseignantAn.Find(id);
            db.ConsEnseignantAn.Remove(consEnseignantAn);
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

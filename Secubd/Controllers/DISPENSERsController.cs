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
    public class DISPENSERsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DISPENSERs
        public ActionResult Index()
        {
            var dISPENSERs = db.DISPENSERs.Include(d => d.Annee_Academique).Include(d => d.Classe).Include(d => d.Enseignant).Include(d => d.Module);
            return View(dISPENSERs.ToList());
        }

        // GET: DISPENSERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPENSER dISPENSER = db.DISPENSERs.Find(id);
            if (dISPENSER == null)
            {
                return HttpNotFound();
            }
            return View(dISPENSER);
        }

        // GET: DISPENSERs/Create
        public ActionResult Create()
        {
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac");
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv");
            ViewBag.codeEns = new SelectList(db.Enseignants, "codeEns", "nomEns");
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod");
            return View();
        }

        // POST: DISPENSERs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeMod,codeClass,codeEns,libelleAnn_Ac")] DISPENSER dISPENSER)
        {
            if (ModelState.IsValid)
            {
                db.DISPENSERs.Add(dISPENSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", dISPENSER.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", dISPENSER.codeClass);
            ViewBag.codeEns = new SelectList(db.Enseignants, "codeEns", "nomEns", dISPENSER.codeEns);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", dISPENSER.codeMod);
            return View(dISPENSER);
        }

        // GET: DISPENSERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPENSER dISPENSER = db.DISPENSERs.Find(id);
            if (dISPENSER == null)
            {
                return HttpNotFound();
            }
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", dISPENSER.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", dISPENSER.codeClass);
            ViewBag.codeEns = new SelectList(db.Enseignants, "codeEns", "nomEns", dISPENSER.codeEns);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", dISPENSER.codeMod);
            return View(dISPENSER);
        }

        // POST: DISPENSERs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeMod,codeClass,codeEns,libelleAnn_Ac")] DISPENSER dISPENSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISPENSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", dISPENSER.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", dISPENSER.codeClass);
            ViewBag.codeEns = new SelectList(db.Enseignants, "codeEns", "nomEns", dISPENSER.codeEns);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", dISPENSER.codeMod);
            return View(dISPENSER);
        }

        // GET: DISPENSERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISPENSER dISPENSER = db.DISPENSERs.Find(id);
            if (dISPENSER == null)
            {
                return HttpNotFound();
            }
            return View(dISPENSER);
        }

        // POST: DISPENSERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DISPENSER dISPENSER = db.DISPENSERs.Find(id);
            db.DISPENSERs.Remove(dISPENSER);
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

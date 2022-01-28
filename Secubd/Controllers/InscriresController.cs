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
    public class InscriresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscrires
        public ActionResult Index()
        {
            var inscrires = db.Inscrires.Include(i => i.Annee_Academique).Include(i => i.Classe).Include(i => i.Niveau);
            return View(inscrires.ToList());
        }

        // GET: Inscrires/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrire inscrire = db.Inscrires.Find(id);
            if (inscrire == null)
            {
                return HttpNotFound();
            }
            return View(inscrire);
        }

        // GET: Inscrires/Create
        public ActionResult Create()
        {
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac");
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv");
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv");
            return View();
        }

        // POST: Inscrires/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeClass,codeEtud,codeNiv,libelleAnn_Ac")] Inscrire inscrire)
        {
            if (ModelState.IsValid)
            {
                db.Inscrires.Add(inscrire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", inscrire.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", inscrire.codeClass);
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", inscrire.codeNiv);
            return View(inscrire);
        }

        // GET: Inscrires/Edit/5
        public ActionResult Edit(string etu,string classe,string  anne ,string niv)
        {
            
            Inscrire inscrire = db.Inscrires.Where(s=>s.codeClass==classe && s.codeEtud==etu && s.libelleAnn_Ac== anne && s.codeNiv==niv ).FirstOrDefault();
            if (inscrire == null)
            {
                return HttpNotFound();
            }
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", inscrire.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", inscrire.codeClass);
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", inscrire.codeNiv);
            return View(inscrire);
        }

        // POST: Inscrires/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeClass,codeEtud,codeNiv,libelleAnn_Ac")] Inscrire inscrire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscrire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.libelleAnn_Ac = new SelectList(db.Annee_Academique, "libelleAnn_Ac", "libelleAnn_Ac", inscrire.libelleAnn_Ac);
            ViewBag.codeClass = new SelectList(db.Classes, "codeClass", "codeNiv", inscrire.codeClass);
            ViewBag.codeNiv = new SelectList(db.Niveaux, "codeNiv", "libelleNiv", inscrire.codeNiv);
            return View(inscrire);
        }

        // GET: Inscrires/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrire inscrire = db.Inscrires.Find(id);
            if (inscrire == null)
            {
                return HttpNotFound();
            }
            return View(inscrire);
        }

        // POST: Inscrires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inscrire inscrire = db.Inscrires.Find(id);
            db.Inscrires.Remove(inscrire);
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

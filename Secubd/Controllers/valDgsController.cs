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
    public class valDgsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: valDgs
        public ActionResult Index()
        {
            return View(db.valDg.ToList());
        }

        // GET: valDgs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valDg valDg = db.valDg.Find(id);
            if (valDg == null)
            {
                return HttpNotFound();
            }
            return View(valDg);
        }

        // GET: valDgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: valDgs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] valDg valDg)
        {
            if (ModelState.IsValid)
            {
                db.valDg.Add(valDg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valDg);
        }

        // GET: valDgs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valDg valDg = db.valDg.Find(id);
            if (valDg == null)
            {
                return HttpNotFound();
            }
            return View(valDg);
        }

        // POST: valDgs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] valDg valDg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valDg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valDg);
        }

        // GET: valDgs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valDg valDg = db.valDg.Find(id);
            if (valDg == null)
            {
                return HttpNotFound();
            }
            return View(valDg);
        }

        // POST: valDgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            valDg valDg = db.valDg.Find(id);
            db.valDg.Remove(valDg);
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

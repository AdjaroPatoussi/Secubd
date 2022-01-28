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
    public class valChesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: valChes
        public ActionResult Index()
        {
            return View(db.valCh.ToList());
        }

        // GET: valChes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valCh valCh = db.valCh.Find(id);
            if (valCh == null)
            {
                return HttpNotFound();
            }
            return View(valCh);
        }

        // GET: valChes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: valChes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] valCh valCh)
        {
            if (ModelState.IsValid)
            {
                db.valCh.Add(valCh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valCh);
        }

        // GET: valChes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valCh valCh = db.valCh.Find(id);
            if (valCh == null)
            {
                return HttpNotFound();
            }
            return View(valCh);
        }

        // POST: valChes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,dateEval,codeMod,codeEval,nomETudiant,codePar,nomMod,note")] valCh valCh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valCh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valCh);
        }

        // GET: valChes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valCh valCh = db.valCh.Find(id);
            if (valCh == null)
            {
                return HttpNotFound();
            }
            return View(valCh);
        }

        // POST: valChes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            valCh valCh = db.valCh.Find(id);
            db.valCh.Remove(valCh);
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

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
    public class ConsDGChesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConsDGChes
        public ActionResult Index()
        {
            return View(db.ConsDGCh.ToList());
        }

        // GET: ConsDGChes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsDGCh consDGCh = db.ConsDGCh.Find(id);
            if (consDGCh == null)
            {
                return HttpNotFound();
            }
            return View(consDGCh);
        }

        // GET: ConsDGChes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsDGChes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,numeroEtud,nomETudiant,codePar,nomMod,dateEval,note,codeMod,codeEval")] ConsDGCh consDGCh)
        {
            if (ModelState.IsValid)
            {
                consDGCh.Id = Guid.NewGuid();
                db.ConsDGCh.Add(consDGCh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consDGCh);
        }

        // GET: ConsDGChes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsDGCh consDGCh = db.ConsDGCh.Find(id);
            if (consDGCh == null)
            {
                return HttpNotFound();
            }
            return View(consDGCh);
        }

        // POST: ConsDGChes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,numeroEtud,nomETudiant,codePar,nomMod,dateEval,note,codeMod,codeEval")] ConsDGCh consDGCh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consDGCh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consDGCh);
        }

        // GET: ConsDGChes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsDGCh consDGCh = db.ConsDGCh.Find(id);
            if (consDGCh == null)
            {
                return HttpNotFound();
            }
            return View(consDGCh);
        }

        // POST: ConsDGChes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ConsDGCh consDGCh = db.ConsDGCh.Find(id);
            db.ConsDGCh.Remove(consDGCh);
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

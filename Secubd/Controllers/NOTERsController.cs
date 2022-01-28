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
    public class NOTERsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NOTERs
        public ActionResult Index()
        {
            var nOTERs = db.NOTERs.Include(n => n.Etudiant).Include(n => n.Evaluation).Include(n => n.Module);
            return View(nOTERs.ToList());
        }

        // GET: NOTERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTER nOTER = db.NOTERs.Find(id);
            if (nOTER == null)
            {
                return HttpNotFound();
            }
            return View(nOTER);
        }

        // GET: NOTERs/Create
        public ActionResult Create()
        {
            ViewBag.numeroEtud = new SelectList(db.Etudiants, "numeroEtud", "nomEtud");
            ViewBag.codeEval = new SelectList(db.Evaluations, "codeEval", "libelleEval");
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod");
            return View();
        }

        // POST: NOTERs/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroEtud,codeMod,codeEval,note,valide,dateEval")] NOTER nOTER)
        {
            if (ModelState.IsValid)
            {
                db.NOTERs.Add(nOTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numeroEtud = new SelectList(db.Etudiants, "numeroEtud", "nomEtud", nOTER.numeroEtud);
            ViewBag.codeEval = new SelectList(db.Evaluations, "codeEval", "libelleEval", nOTER.codeEval);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", nOTER.codeMod);
            return View(nOTER);
        }

        // GET: NOTERs/Edit/5
        public ActionResult Edit(string mod ,string etu,string eval )
        {
            if (etu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTER nOTER = db.NOTERs.Where(s=>s.codeEval==eval && (s.codeMod==mod) && (s.numeroEtud==etu)).FirstOrDefault();
            if (nOTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.numeroEtud = new SelectList(db.Etudiants, "numeroEtud", "nomEtud", nOTER.numeroEtud);
            ViewBag.codeEval = new SelectList(db.Evaluations, "codeEval", "libelleEval", nOTER.codeEval);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", nOTER.codeMod);
            return View(nOTER);
        }

        public ActionResult Valider(string mod, string etu, string eval)
        {
            if (etu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTER nOTER = db.NOTERs.Where(s => s.codeEval == eval && (s.codeMod == mod) && (s.numeroEtud == etu)).FirstOrDefault();
            if (nOTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.numeroEtud = new SelectList(db.Etudiants, "numeroEtud", "nomEtud", nOTER.numeroEtud);
            ViewBag.codeEval = new SelectList(db.Evaluations, "codeEval", "libelleEval", nOTER.codeEval);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", nOTER.codeMod);
            return View(nOTER);
        }

        // POST: NOTERs/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroEtud,codeMod,codeEval,note,valide,dateEval")] NOTER nOTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTER).State = EntityState.Modified;
                db.SaveChanges();

                if(User.Identity.IsAuthenticated && User.IsInRole(roleUtilisateur.enseignantRole))
                {
                    return RedirectToAction("Index", "ValEnseignants");
                }
                
                
            }
            ViewBag.numeroEtud = new SelectList(db.Etudiants, "numeroEtud", "nomEtud", nOTER.numeroEtud);
            ViewBag.codeEval = new SelectList(db.Evaluations, "codeEval", "libelleEval", nOTER.codeEval);
            ViewBag.codeMod = new SelectList(db.Modules, "codeMod", "nomMod", nOTER.codeMod);
            return View(nOTER);
        }

        

        // GET: NOTERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTER nOTER = db.NOTERs.Find(id);
            if (nOTER == null)
            {
                return HttpNotFound();
            }
            return View(nOTER);
        }

        // POST: NOTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NOTER nOTER = db.NOTERs.Find(id);
            db.NOTERs.Remove(nOTER);
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

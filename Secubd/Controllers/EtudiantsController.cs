using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Secubd.Models;

namespace Secubd.Controllers
{
    public class EtudiantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Etudiants
        [Authorize(Roles = roleUtilisateur.adminRole)]
        public async Task<ActionResult> Index()
        {
            var etudiants = db.Etudiants.Include(e => e.Parcour);
            return View(await etudiants.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant =  db.Etudiants.Where(e=>e.numeroEtud==id).FirstOrDefault();
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // GET: Etudiants/Create
        public ActionResult Create()
        {
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar");
            return View();
        }

        // POST: Etudiants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "numeroEtud,nomEtud,prenomEtud,sexe,dateNaissance,codePar,logEtu,mdpEtu")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", etudiant.codePar);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = await db.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", etudiant.codePar);
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "numeroEtud,nomEtud,prenomEtud,sexe,dateNaissance,codePar,logEtu,mdpEtu")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.codePar = new SelectList(db.Parcours, "codePar", "libellePar", etudiant.codePar);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = await db.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Etudiant etudiant = await db.Etudiants.FindAsync(id);
            db.Etudiants.Remove(etudiant);
            await db.SaveChangesAsync();
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

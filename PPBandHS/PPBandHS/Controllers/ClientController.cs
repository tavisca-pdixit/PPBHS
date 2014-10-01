using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPBandHS.Models;

namespace PPBandHS.Controllers
{
    public class ClientController : Controller
    {
        private ClientDbContext db = new ClientDbContext();

        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id = 0)
        {
            ClientModel clientmodel = db.Clients.Find(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            return View(clientmodel);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(clientmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientmodel);
        }

        //
        // GET: /Client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClientModel clientmodel = db.Clients.Find(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            return View(clientmodel);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientmodel);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClientModel clientmodel = db.Clients.Find(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            return View(clientmodel);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientModel clientmodel = db.Clients.Find(id);
            db.Clients.Remove(clientmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
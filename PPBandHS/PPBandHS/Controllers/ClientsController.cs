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
    public class ClientsController : Controller
    {
        private ClientsContext db = new ClientsContext();

        //
        // GET: /Clients/

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Clients/Details/5

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
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Clients/Create

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
        // GET: /Clients/Edit/5

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
        // POST: /Clients/Edit/5

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
        // GET: /Clients/Delete/5

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
        // POST: /Clients/Delete/5

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
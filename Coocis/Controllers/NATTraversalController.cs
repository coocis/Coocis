using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coocis.Models;
using System.Text.RegularExpressions;

namespace Coocis.Controllers
{
    public class NATTraversalController : Controller
    {
        private System.Web.HttpContext _currentContext = System.Web.HttpContext.Current;

        private NATTraversalDBContext db = new NATTraversalDBContext();
        [AllowAnonymous]
        // GET: NATTraversal
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        [AllowAnonymous]
        // GET: NATTraversal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATTraversalModels nATTraversalModels = db.Articles.Find(id);
            if (nATTraversalModels == null)
            {
                return HttpNotFound();
            }
            return View(nATTraversalModels);
        }

        [AllowAnonymous]
        // GET: NATTraversal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NATTraversal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServerName,ServiceAddress")] NATTraversalModels natTraversalModels)
        {
            if (ModelState.IsValid)
            {
                natTraversalModels.ServiceAddress = Regex.Replace(natTraversalModels.ServiceAddress, "localhost", GetIP());
                db.Articles.Add(natTraversalModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(natTraversalModels);
        }

        // GET: NATTraversal/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATTraversalModels nATTraversalModels = db.Articles.Find(id);
            if (nATTraversalModels == null)
            {
                return HttpNotFound();
            }
            return View(nATTraversalModels);
        }

        // POST: NATTraversal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Edit([Bind(Include = "ID,ServerName,ServiceAddress")] NATTraversalModels natTraversalModels)
        {
            if (ModelState.IsValid)
            {
                natTraversalModels.ServiceAddress = Regex.Replace(natTraversalModels.ServiceAddress, "localhost", GetIP());
                db.Entry(natTraversalModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(natTraversalModels);
        }

        // GET: NATTraversal/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATTraversalModels nATTraversalModels = db.Articles.Find(id);
            if (nATTraversalModels == null)
            {
                return HttpNotFound();
            }
            return View(nATTraversalModels);
        }

        // POST: NATTraversal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult DeleteConfirmed(int id)
        {
            NATTraversalModels nATTraversalModels = db.Articles.Find(id);
            db.Articles.Remove(nATTraversalModels);
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

        private string GetIP()
        {
            string VisitorsIPAddr = string.Empty;
            if (_currentContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = _currentContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (_currentContext.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = _currentContext.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }
    }
}

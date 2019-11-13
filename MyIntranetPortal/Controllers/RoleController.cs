using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyIntranetPortal.Models;

namespace MyIntranetPortal.Controllers
{
    public class RoleController : Controller
    {
        private IntraPortalEntities1 db = new IntraPortalEntities1();

        // GET: Role
        public ActionResult Index()
        {

            return View(db.CMS_Role.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Role cMS_Role = db.CMS_Role.Find(id);
            if (cMS_Role == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleDisplayName,RoleName")] CMS_Role cMS_Role)
        {
            if (ModelState.IsValid)
            {
                db.CMS_Role.Add(cMS_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMS_Role);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Role cMS_Role = db.CMS_Role.Find(id);
            if (cMS_Role == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleDisplayName,RoleName,RoleDescription,SiteID,RoleGUID,RoleLastModified,RoleGroupID,RoleIsGroupAdministrator,RoleIsDomain")] CMS_Role cMS_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMS_Role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_Role cMS_Role = db.CMS_Role.Find(id);
            if (cMS_Role == null)
            {
                return HttpNotFound();
            }
            return View(cMS_Role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_Role cMS_Role = db.CMS_Role.Find(id);
            db.CMS_Role.Remove(cMS_Role);
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

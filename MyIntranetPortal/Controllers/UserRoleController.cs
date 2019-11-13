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
    public class UserRoleController : Controller
    {
        private IntraPortalEntities1 db = new IntraPortalEntities1();

        // GET: UserRole
        public ActionResult Index()
        {
            var cMS_UserRole = db.CMS_UserRole.Include(c => c.CMS_Role).Include(c => c.CMS_User);
            return View(cMS_UserRole.ToList());
        }

        // GET: UserRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);
            if (cMS_UserRole == null)
            {
                return HttpNotFound();
            }
            return View(cMS_UserRole);
        }

        // GET: UserRole/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName");
            ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName");
            return View();
        }

        // POST: UserRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,RoleID,ValidTo,UserRoleID")] CMS_UserRole cMS_UserRole)
        {
            if (ModelState.IsValid)
            {
                db.CMS_UserRole.Add(cMS_UserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName", cMS_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName", cMS_UserRole.UserID);
            return View(cMS_UserRole);
        }

        // GET: UserRole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);
            if (cMS_UserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName", cMS_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName", cMS_UserRole.UserID);
            return View(cMS_UserRole);
        }

        // POST: UserRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,RoleID,ValidTo,UserRoleID")] CMS_UserRole cMS_UserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS_UserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName", cMS_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName", cMS_UserRole.UserID);
            return View(cMS_UserRole);
        }

        // GET: UserRole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);
            if (cMS_UserRole == null)
            {
                return HttpNotFound();
            }
            return View(cMS_UserRole);
        }

        // POST: UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);
            db.CMS_UserRole.Remove(cMS_UserRole);
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

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
    public class UserController : Controller
    {
        private IntraPortalEntities1 db = new IntraPortalEntities1();

        // GET: User
        public ActionResult Index()
        {
            return View(db.CMS_User.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_User cMS_User = db.CMS_User.Find(id);
            if (cMS_User == null)
            {
                return HttpNotFound();
            }
            return View(cMS_User);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserID,UserName,FirstName,MiddleName,LastName,FullName,Email,UserPassword,PreferredCultureCode,PreferredUICultureCode,UserEnabled,UserIsExternal,UserPasswordFormat,UserCreated,LastLogon,UserStartingAliasPath,UserGUID,UserLastModified,UserLastLogonInfo,UserIsHidden,UserVisibility,UserIsDomain,UserHasAllowedCultures,UserMFRequired,UserPrivilegeLevel,UserSecurityStamp,UserMFSecret,UserMFTimestep")] CMS_User cMS_User)
        public ActionResult Create([Bind(Include = "UserName,UserPassword")] CMS_User cMS_User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CMS_User.Add(cMS_User);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                ViewData["Message"] = e.Message;
                return RedirectToAction("Index");
            }
            return View(cMS_User);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_User cMS_User = db.CMS_User.Find(id);
            if (cMS_User == null)
            {
                return HttpNotFound();
            }
            return View(cMS_User);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,FirstName,MiddleName,LastName,FullName,Email,UserPassword,PreferredCultureCode,PreferredUICultureCode,UserEnabled,UserIsExternal,UserPasswordFormat,UserCreated,LastLogon,UserStartingAliasPath,UserGUID,UserLastModified,UserLastLogonInfo,UserIsHidden,UserVisibility,UserIsDomain,UserHasAllowedCultures,UserMFRequired,UserPrivilegeLevel,UserSecurityStamp,UserMFSecret,UserMFTimestep")] CMS_User cMS_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMS_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMS_User);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMS_User cMS_User = db.CMS_User.Find(id);
            if (cMS_User == null)
            {
                return HttpNotFound();
            }
            return View(cMS_User);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_User cMS_User = db.CMS_User.Find(id);
            CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);
            db.CMS_UserRole.Remove(cMS_UserRole);
            db.SaveChanges();
            db.CMS_User.Remove(cMS_User);
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

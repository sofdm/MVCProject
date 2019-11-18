using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyIntranetPortal.Models;
using System.Web.Mvc.Html;


namespace MyIntranetPortal.Controllers
{
    public class HomeController : Controller
    {
        private IntraPortalEntities1 db = new IntraPortalEntities1();

        // GET: User
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "username")
            {
                return View(db.CMS_User.Where(x => x.UserName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "fullname")
            {
                return View(db.CMS_User.Where(x => x.FullName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.CMS_User.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }
        }


        public ActionResult Details(int? id)
        {
            ViewModel model = new ViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model.users = db.CMS_User.Find(id);
            //CMS_User cMS_User = db.CMS_User.Find(id);
            if (model.users == null)
            {
                return HttpNotFound();
            }

            var query = from cMS_User1 in db.CMS_User
                        join cMS_UserRole in db.CMS_UserRole on cMS_User1.UserID equals cMS_UserRole.UserID
                        join cMS_Role in db.CMS_Role on cMS_UserRole.RoleID equals cMS_Role.RoleID
                        where cMS_User1.UserID == model.users.UserID
                        select cMS_Role;

            model.roles = query.ToList();             
                return View(model);
        }

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

        //POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMS_User cMS_User = db.CMS_User.Find(id);
            CMS_Role cMS_Role = new CMS_Role();
            CMS_UserRole cMS_UserRole = new CMS_UserRole();

            db.CMS_User.Remove(cMS_User);
            db.SaveChanges();
            TempData["delete"] = "success";
            return RedirectToAction("Index");
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
        public ActionResult Create([Bind(Include = "UserName,FirstName,UserPassword,LastName,MiddleName,FullName,Email")] CMS_User cMS_User)
        {   
            cMS_User.UserGUID = Guid.NewGuid();
            try
            {
                if (ModelState.IsValid)
                {           
                    db.CMS_User.Add(cMS_User);
                    db.SaveChanges();
                    TempData["message"] = "success";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
            return RedirectToAction("Index");
            //return View(cMS_User);
        }


        public ActionResult CreateRole(int id)
        {
            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName");
           // ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole([Bind(Include = "RoleID,ValidTo,UserRoleID")] CMS_UserRole cMS_UserRole)
        {
            if (ModelState.IsValid)
            {
                
                db.CMS_UserRole.Add(cMS_UserRole);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.RoleID = new SelectList(db.CMS_Role, "RoleID", "RoleDisplayName", cMS_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.CMS_User, "UserID", "UserName", cMS_UserRole.UserID);
            return View(cMS_UserRole);
        }


        // GET: UserRole/Delete/5
        /*  public ActionResult DeleteRole(int? id)
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
        [HttpPost, ActionName("DeleteRole")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteRoleConfirmed(int id)
         {
             CMS_UserRole cMS_UserRole = db.CMS_UserRole.Find(id);

             db.CMS_UserRole.Remove(cMS_UserRole);
             db.SaveChanges();
             return RedirectToAction("Index");
         }*/

        // GET: Role/Delete/5
        public ActionResult DeleteRole(int? id)
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
        public ActionResult DeleteRoleConfirmed(int id)
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
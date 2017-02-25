using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAA.Models;

namespace NAA.Controllers
{
    [Authorize(Roles= Helpers.Constants.Roles.Admin)]
    public class AdminController : Controller
    {
        private Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext _context;

        public AdminController()
        {
            _context = new Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext();
        }

        public ActionResult GetUsers()
        {
            return View(_context.Users.ToList());
        }

        //Implement the HttpGet action     
        [HttpGet]
        public ActionResult CreateRole() { return View(); }
        //saving the createRole     
        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            } catch { return View(); }
        }


        //get roles    
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }



        [HttpGet]
        public ActionResult ManageUserRoles(string userName)
        {
            var model = GetUserViewModel(userName);

            return View(model);
        }

        private UserViewModel GetUserViewModel(string userName)
        {
        //populate roles for the view dropdown  
            var roleList =
                _context.Roles.OrderBy(r => r.Name)
                    .ToList()
                    .Select(rr => new SelectListItem {Value = rr.Name.ToString(), Text = rr.Name})
                    .ToList();
            
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
            var roleId = user.Roles.FirstOrDefault().RoleId;
            
            var model = new UserViewModel
            {
                UserName = user.UserName,
                UserId = user.Id,
                Roles = roleList
            };

            if (_context.Roles.Any(x => x.Id == roleId))
            {
                model.RoleName = _context.Roles.First(x => x.Id == roleId).Name;
            }

            return model;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(UserViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(model.UserName, StringComparison.CurrentCultureIgnoreCase));
            var um = new Microsoft.AspNet.Identity.UserManager<IdentityUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<IdentityUser>(_context));
           
            um.RemoveFromRole(user.Id, Helpers.Constants.Roles.Applicant);
            um.RemoveFromRole(user.Id, Helpers.Constants.Roles.Admin);
            um.RemoveFromRole(user.Id, Helpers.Constants.Roles.Staff);
            var idResult = um.AddToRole(user.Id, model.RoleName);

            model = GetUserViewModel(model.UserName);
            
            return View("ManageUserRoles", model);
        }

        //Get Roles for users       
        [HttpGet]
        public ActionResult GetRolesforUser()
        {
            return View();

        }


        //http post for GetRolesforUsers   
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult GetRolesforUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));
                var um = new Microsoft.AspNet.Identity.UserManager<IdentityUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<IdentityUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesforUserConfirmed");

        }         // GET: Admin   

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5 
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create  
        public ActionResult Create() { return View(); }

        // POST: Admin/Create 
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {                 // TODO: Add insert logic here 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5 
        public ActionResult Edit(int id) { return View(); }

        // POST: Admin/Edit/5    
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {                 // TODO: Add update logic here 

                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        // GET: Admin/Delete/5   
        public ActionResult Delete(int id) { return View(); }

        // POST: Admin/Delete/5  
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {                 // TODO: Add delete logic here 

                return RedirectToAction("Index");
            }
            catch { return View(); }
        }
    }
}
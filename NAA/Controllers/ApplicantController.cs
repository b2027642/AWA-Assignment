using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IServices;

namespace NAA.Controllers
{
    /// <summary>
    /// Interface to handle UI operations
    /// </summary>
    [Authorize(Roles = Helpers.Constants.Roles.Applicant)]
    public class ApplicantController : Controller
    {

        private IApplicantService _applicantService;

        /// <summary>
        /// Constructor to initialize class object
        /// </summary>
        public ApplicantController()
        {
            _applicantService = new ApplicantService();
        }
        // GET: Applicant
        /*public ActionResult Applicants()
        {
            return View(_applicantService.GetApplicants());
        }*/

        public ActionResult Applicant(int id)
        {
            return View(_applicantService.GetApplicant(id));

        }

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applicant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

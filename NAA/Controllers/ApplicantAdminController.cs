using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Services.Service;
using NAA.Services.IServices;
using NAA.Data;

namespace NAA.Controllers
{
    [Authorize(Roles = Helpers.Constants.Roles.Applicant)]
    public class ApplicantAdminController : Controller
    {
        private IApplicantService _applicantService;

        public ApplicantAdminController()
        {
            _applicantService = new ApplicantService();
        }
        
        
        //GET: ApplicantAdmin
        public ActionResult Index()
        {
            return View(_applicantService.GetApplicants());
        }

        //getting data for edit left at this point
        [HttpGet]
        public ActionResult EditApplicant (int Id)
        {
            return View(_applicantService.GetApplicant(Id));
        }

        //posting method once data has been collecetd via the get method for edit

        [HttpPost]
        public ActionResult EditApplicant(Applicant applicant)
        {
            try
            {
                _applicantService.EditApplicant(applicant);
                return RedirectToAction("Applicant", new { id = applicant.ApplicantId, Controller = "Applicant" });
            }
            catch
            {
                return View();
            }
        }

        //get action before creating
        [HttpGet]
        public ActionResult AddApplicant(string applicant)
        {
            return View();
        }
        //Add action for adding an applicant to the database
        [HttpPost]

        public ActionResult AddApplicant(Applicant applicant)
        {
            _applicantService.AddApplicant(applicant);
            return RedirectToAction("Applicant", new { id = applicant.ApplicantId, Controller = "Applicant" });
        }






    }
}
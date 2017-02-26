using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        public ActionResult Applicant()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var applicant = _applicantService.GetApplicant(userId);
            return View(applicant);

        }
    }
}

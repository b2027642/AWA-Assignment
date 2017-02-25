using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAA.Data;
using NAA.Helpers;
using NAA.Models;
using NAA.Services.IServices;
using NAA.Services.Service;
using NAA.SheffieldUniCourses;
using NAA.SHUWebService;

namespace NAA.Controllers
{

    /// Interface to handle UI operations
    [Authorize(Roles = Helpers.Constants.Roles.Applicant)]
    public class ApplicationController : Controller
    {
        private IApplicationService _applicationService;
        private IUniversityService _universityService;
        private IApplicantService _applicantService;
        private readonly UniversityHelper _universityHelper;

        /// Constructor to initlize class object

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
            _universityService = new UniversityService();
            _applicantService = new ApplicantService();
            _universityHelper = new UniversityHelper();
        }

        public UniversityHelper UniversityHelper
        {
            get { return _universityHelper; }
        }


        /// Action for listing application for applicant
        /// <returns>Index view that contains listing of applications</returns>
        public ActionResult Index()
        {
            var userId = HttpContext.User.Identity.GetUserId();

            var applicant = _applicantService.GetApplicants().Where(x => x.UserID == userId).FirstOrDefault();
            var model = new ApplicationListViewModel();

            if (applicant != null)
            {
                int applicantId = applicant.ApplicantId;
                model.Applications = _applicationService.GetApplicationsByApplicant(applicantId);
                model.ApplicantId = applicantId;
            }

            return View("Index", model);
        }

     
        /// Action to load application in add mode for new application or in edit mode for edit
        /// <param name="applicantId">Applicant id to which application belongs</param>
        /// <param name="applicationId">Application id to edit or null for new application</param>
        /// <returns>Edit page</returns>
        [HttpGet]
        public ActionResult Edit(int applicantId, int? applicationId)
        {
            ApplicationViewModel model = GetApplicationModel(applicantId, applicationId);
            
            return View("EditApplication", model);
        }

        /// Action to load application in add mode for new application or in edit mode for edit
        /// <param name="applicantId">Applicant id to which application belongs</param>
        /// <param name="applicationId">Application id to edit or null for new application</param>
        /// <returns>Edit page</returns>
        [HttpGet]
        public ActionResult DisplayApplication(int applicantId, int? applicationId)
        {
            ApplicationViewModel model = GetApplicationModel(applicantId, applicationId);
           
            return View("DisplayApplication", model);
        }


        private ApplicationViewModel GetApplicationModel(int applicantId, int? applicationId)
        {
           var model = new ApplicationViewModel();
            
            if (!applicationId.HasValue)
            {
                model.ApplicantId = applicantId;
                model.ApplicantName = _applicantService.GetApplicant(applicantId).ApplicantName;
            }
            else
            {
                var application = _applicationService.GetApplication(applicationId.Value);

                if (application == null)
                {
                    return model;
                }

                model.ApplicationId = application.ApplicantId;
                model.CourseName = application.CourseName.Trim();
                model.PersonalStatement = application.PersonalStatement;
                model.TeacherReference = application.TeacherReference;
                model.TeacherContactDetails = application.TeacherContactDetails.Trim();
                model.UniversityId = application.UniversityId;
                model.UniversityOffer = application.UniversityOffer;
                model.Firm = application.Firm;
                model.ApplicantId = application.ApplicantId;
                model.ApplicantName = application.Applicant.ApplicantName.Trim();
                model.OfferCondition = application.OfferCondition;
                model.RejectReason = application.RejectReason;

                var university = _universityHelper.GetUniversity(model.UniversityId);

                if (university != null)
                {
                    model.UniversityName = university.UniversityName.Trim();
                }
            }

            model = SetApplicationViewModel(model);

            var courses = _universityHelper.GetCourses(model.UniversityId);

            if (courses.Any(x => x.CourseName == model.CourseName))
            {
                var course = courses.First(x => x.CourseName == model.CourseName);

                model.CourseContent = course.CourseContent.Trim();
                model.CourseDescription = course.CourseDescription.Trim();
                model.EntryCriteria = course.EntryCriteria.Trim();
            }

            return model;
        }


        /// Method to set field for drop-down list
        /// <param name="model"></param>
        /// <returns></returns>
        private ApplicationViewModel SetApplicationViewModel(ApplicationViewModel model)
        {
            var universities = _universityService.GetUniversities();
            model.Universities = universities
                .Select(s => new SelectListItem
                {
                    Value = s.UniversityId.ToString(),
                    Text = s.UniversityName.Trim()
                }).ToList();

            if (model.UniversityId > 0)
            {
                model.Courses = UniversityHelper.GetCourses(model.UniversityId).Select(s => new SelectListItem
                {
                    Value = s.CourseName,
                    Text = s.CourseName.Trim()
                }).ToList();
            }
            else
            {
                model.Courses = UniversityHelper.GetCourses(universities.First().UniversityId).Select(s => new SelectListItem
                {
                    Value = s.CourseName,
                    Text = s.CourseName.Trim()
                }).ToList();
            }

            return model;
        }


        /// Action to save application
        /// <param name="model"></param>
        /// <returns>Redirect to applications list page or stay on same page if any errors occur </returns>
        [HttpPost]
        public ActionResult Edit(ApplicationViewModel model)
        {
            try
            {
                model = SetApplicationViewModel(model);

                if (ModelState.IsValid)
                {
                    var application = new Application
                    {
                        ApplicationId = model.ApplicationId,
                        CourseName = model.CourseName,
                        PersonalStatement = model.PersonalStatement,
                        TeacherReference = model.TeacherReference,
                        TeacherContactDetails = model.TeacherContactDetails,
                        UniversityId = model.UniversityId,
                        UniversityOffer = model.UniversityOffer,
                        Firm = model.Firm,
                        ApplicantId = model.ApplicantId
                    };

                    _applicationService.Save(application);

                    model.ApplicationId = application.ApplicationId;

                    return RedirectToAction("Index", new { applicantId = model.ApplicantId });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Unexpected error occurs");
            }

            return View("EditApplication", model);
        }

        /// Delete application for particuler applicant
        /// <param name="applicationId"></param>
        /// <param name="applicantId"></param>
        [HttpPost]
        public ActionResult Delete(int applicationId, int applicantId)
        {
            _applicationService.Delete(applicationId);
            return RedirectToAction("Index", new { applicantId });
        }

        /// Action to accept offer
        /// <param name="applicationId"></param>
        /// <param name="applicantId"></param>
        [HttpPost]
        public ActionResult SetFirm(int applicationId, int applicantId)
        {
            _applicationService.Firm(applicationId);
            return RedirectToAction("Index", new { applicantId });
        }
        
        public JsonResult GetCourses(int universityId)
        {
            var courses = _universityHelper.GetCourses(universityId);
            return Json(courses);
        }

       
    }
}
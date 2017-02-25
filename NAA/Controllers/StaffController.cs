using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;
using NAA.Helpers;
using NAA.Services.IServices;
using NAA.Services.Service;

namespace NAA.Controllers
{
    [Authorize(Roles = Helpers.Constants.Roles.Staff)]
    public class StaffController : Controller
    {
        private readonly IUniversityService _universityService;
        private readonly UniversityHelper _universityHelper;

        public StaffController()
        {
            _universityService = new UniversityService();
            _universityHelper = new UniversityHelper();
        }

        // GET: Staff
        public ActionResult Index()
        {
            var universities = _universityService.GetUniversities();
            return View(universities);
        }

        [HttpGet]
        public ActionResult EditUniversity(int? universityId)
        {
            University model;

            if (universityId.HasValue)
            {
                model =
                    _universityService.GetUniversity(universityId.Value);
            }
            else
            {
                model=new University();
            }

            return View(model);
        }

        public ActionResult EditUniversity(University model)
        {
            _universityService.EditUniversity(model);

            return View(model);
        }

        // GET: Staff
        public ActionResult Courses(int universityId)
        {
            var universities = _universityService.GetUniversities();
            ViewBag.UniversityName = universities.First(x => x.UniversityId == universityId).UniversityName;

            var courses = _universityHelper.GetCourses(universityId);
            return View(courses);
        }
    }
}
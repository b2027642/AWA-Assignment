using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NAA.Controllers;
using NAA.Data;
using NAA.Services.IServices;
using NAA.Services.Service;
using NAA.SHUWebService;

namespace NAA.Helpers
{
    public class UniversityHelper
    {
        private IUniversityService _universityService;

        public UniversityHelper()
        {
            _universityService = new UniversityService();
        }

        public University GetUniversity(int universityId)
        {
            return _universityService.GetUniversity(universityId);
        }

        /// Action for ajax request made to get courses on university change dropdown in the EditApplication.cshtml
        /// <param name="universityId"></param>
        /// <returns></returns>
        public IList<CourseList> GetCourses(int universityId)
        {
            var courses = GetCoursesByUniversityId(universityId);
            return courses;
        }

        /// Get courses for university based on university id if its 1 then its UniOfsheffield
        /// other than that it's shu courses
        /// <param name="universityId">University id</param>
        /// <returns>Course list for university</returns>
        private IList<CourseList> GetCoursesByUniversityId(int universityId)
        {
            if (universityId == 1)
            {
                return GetCoursesSheffield();
            }

            return GetCoursesShu();

        }

        /// Course list for Sheffield 
        /// //also mapping the entryRequirement to be same in both universities using the new CourseList
        /// <returns>Course list for university</returns>
        private IList<CourseList> GetCoursesSheffield()
        {
            var service = new SheffieldUniCourses.SheffieldUniCourses();
            var courses = service.GetCoursesFullDetails();

            return courses.Select(s => new CourseList
            {
                CourseId = s.Id,
                CourseName = s.Name,
                CourseDescription = s.Description,
                CourseContent = s.EntryReq,
                EntryCriteria = s.Tarif.ToString()
            }).ToList();
        }

        /// Course list for SHU 
        /// <returns>Course list for university</returns>
        private IList<CourseList> GetCoursesShu()
        {
            var service = new SHUWebService.SHUWebService();
            var courses = service.GetAllCourses();

            return courses.Select(s => new CourseList
            {
                CourseId = s.CourseId,
                CourseName = s.CourseName,
                CourseDescription = s.CourseDescription,
                CourseContent = s.CourseContent,
                EntryCriteria = s.EntryCriteria
            }).ToList();
        }
    }
}
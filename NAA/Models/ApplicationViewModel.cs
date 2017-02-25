using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using NAA.SheffieldUniCourses;

namespace NAA.Models
{
    [Serializable]
    public class ApplicationViewModel
    {
        [Display(Name = "Application Id")]
        public int ApplicationId { get; set; }

        [Required]//	Indicates that the property is a required field
        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }

        
        [Display(Name = "Applicant Name")]
        public string ApplicantName { get; set; }

        [Required] //	Indicates that the property is a required field
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required] //	Indicates that the property is a required field
        [Display(Name = "University Name")]
        public int UniversityId { get; set; }

        [Display(Name = "University Name")]
        public string UniversityName { get; set; }

        [Required] //	Indicates that the property is a required field
        [Display(Name = "Personal Statement")]
        public string PersonalStatement { get; set; }

        [Required] //	Indicates that the property is a required field
        [Display(Name = "Teacher Reference")]
        public string TeacherReference { get; set; }

        [Required] //	Indicates that the property is a required field
        [Display(Name = "Teacher Contact")]
        public string TeacherContactDetails { get; set; }

        [Display(Name = "University Offer")]
        public string UniversityOffer { get; set; }

        [Display(Name = "Firm")]
        public bool? Firm { get; set; }

        [Display(Name = "Offer Condition")]
        public string OfferCondition { get; set; }

        [Display(Name = "Reject Reason")]
        public string RejectReason { get; set; }

        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Display(Name = "Entry Criteria")]
        public string EntryCriteria { get; set; }

        [Display(Name = "Course Content")]
        public string CourseContent { get; set; }

        [XmlIgnore]
        public IList<SelectListItem> Courses { get; set; }
        [XmlIgnore]
        public IList<SelectListItem> Universities { get; set; }
        //[XmlIgnore]
        //public IList<SelectListItem> Applicants { get; set; }
    }
}
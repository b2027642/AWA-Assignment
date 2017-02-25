using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAA.Data;

namespace NAA.Models
{
    public class ApplicationListViewModel
    {
        public string SuccessMessage { get; set; }
        public IList<Application> Applications { get; set; }
        public int ApplicantId { get; set; }
    }
}
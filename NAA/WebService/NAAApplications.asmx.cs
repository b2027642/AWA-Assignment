using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AutoMapper;
using NAA.Data;
using NAA.Models;
using NAA.Services.IServices;
using NAA.Services.Service;

namespace NAA.WebService
{
    /// <summary>
    /// Summary description for NAAApplications
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NAAApplications : System.Web.Services.WebService
    {
        private IApplicationService _applicationService;

        public NAAApplications()
        {
            _applicationService = new ApplicationService();
        }

        /// List of applications for given university id
        /// <param name="universityId"></param>
        /// <returns></returns>
        [WebMethod]
        public List<ApplicationViewModel> GetApplications(int universityId)
        {
            return Mapper.Map<List<ApplicationViewModel>> ( _applicationService.GetApplications(universityId));
        }

        /// Application for given application id
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [WebMethod]
        public ApplicationViewModel GetApplication(int applicationId)
        {
            return Mapper.Map<ApplicationViewModel>(_applicationService.GetApplication(applicationId));
        }

        /// <summary>
        /// Update applcation with offer detail supplied on parameters
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="offer"></param>
        /// <param name="condition"></param>
        /// <param name="rejectReason"></param>
        /// <returns></returns>
        [WebMethod]
        public string MakeOffer(int applicationId, string offer, string condition, string rejectReason)
        {
            if(applicationId<=0) throw new ApplicationException("Invalid application id");

            if (string.IsNullOrEmpty(offer)) throw new ApplicationException("Invalid offer");

            if ((offer.Trim().ToUpper() == "C" || offer.Trim().ToUpper() == "CONDITIONAL") && string.IsNullOrEmpty(condition))
            {
                throw new ApplicationException("for conditional offer, condition must be non empty");
            }

            var application = _applicationService.GetApplication(applicationId);

            if(application==null) throw new ApplicationException("Invalid application id");

            application.UniversityOffer = offer.Trim().ToUpper();

            if (offer.Trim().ToUpper() == "C" || offer.Trim().ToUpper() == "CONDITIONAL")
            {
                application.OfferCondition = condition;
                application.RejectReason = string.Empty;
            }

            if (offer.Trim().ToUpper() == "R" || offer.Trim().ToUpper() == "REJECT")
            {
                application.RejectReason = rejectReason;
                application.OfferCondition = string.Empty;
            }


            _applicationService.Save(application);

            return "Application updated successfully.";
        }

    }
}

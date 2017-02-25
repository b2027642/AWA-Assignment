using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Services.IServices;
using NAA.Data;
using NAA.Data.IDAO;

//using NAA.Data.DAO;
//using NAA.Data.IDAO;


namespace NAA.Services.Service
{


    public class ApplicationService : IApplicationService
    {
        private IApplicationDAO _applicationDAO;
        public ApplicationService()
        {
            _applicationDAO = new NAA.Data.DAO.ApplicationDAO();
        }

        /// Get list of applications method
        public IList<Application> GetApplications()
        {
            return _applicationDAO.GetApplications();
        }

        /// Get list of application for given university method
        /// <param name="universityId"></param>
        public IList<Application> GetApplications(int universityId)
        {
            return _applicationDAO.GetApplications(universityId);
        }

        /// Get list of application for given applicant method
        /// <param name="applicantId"></param>
        public IList<Application> GetApplicationsByApplicant(int applicantId)
        {
            return _applicationDAO.GetApplicationsByApplicant(applicantId);
        }

        /// Get application for given application id method
        /// <param name="applicationId"></param>
        public Application GetApplication(int applicationId)
        {
            return _applicationDAO.GetApplication(applicationId);
        }


        /// Edit application method
        /// <param name="application"></param>
        public void EditApplication(Application application)
        {
            _applicationDAO.EditApplication(application);
        }

        /// Add new application
        /// <param name="application"></param>
        public void AddApplication(Application application)
        {
            _applicationDAO.AddApplication(application);
        }

        /// Add new application or edit application
        /// <param name="application"></param>
        public void Save(Application application)
        {
            _applicationDAO.Save(application);
        }

        /// Delete application method
        /// <param name="applicationId"></param>
        public void Delete(int applicationId)
        {
            _applicationDAO.Delete(applicationId);
        }

        /// Update application status to accept offer method
        /// <param name="applicationId"></param>
        public void Firm(int applicationId)
        {
            _applicationDAO.Firm(applicationId);
        }
    }


}

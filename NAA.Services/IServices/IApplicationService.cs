using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
//using NAA.Data.DAO;
//using NAA.Data.IDAO;




namespace NAA.Services.IServices
{


    /// Interface to handle application related logic
    public interface IApplicationService
    {
        /// Get list of applications
        IList<Application> GetApplications();

        /// Get list of application for given university
        /// <param name="universityId"></param>
        /// 
        IList<Application> GetApplications(int universityId);

        /// Get list of application for given applicant
        /// <param name="applicantId"></param>
        IList<Application> GetApplicationsByApplicant(int applicantId);

        /// Get application for given application id
        /// <param name="applicationId"></param>
        Application GetApplication(int applicationId);

        /// Edit application
        /// <param name="application"></param>
        void EditApplication(Application application);

        /// Add new application
        /// <param name="application"></param>
        void AddApplication(Application application);

        /// Add new application or edit application
        /// <param name="application"></param>
        void Save(Application application);

        /// Delete application
        /// <param name="applicationId"></param>
        void Delete(int applicationId);

        /// Update application status to accept offer
        /// <param name="applicationId"></param>
        void Firm(int applicationId);
    }
}

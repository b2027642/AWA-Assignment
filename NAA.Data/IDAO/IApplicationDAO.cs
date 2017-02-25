using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    /// Interface to handel database oprations
    public interface IApplicationDAO
    {

        /// Get list of applications
        IList<Application> GetApplications();


        /// Get list of application for given university
        /// <param name="universityId"></param>
        IList<Application> GetApplications(int universityId);



        /// Get list of application for given applicant
        /// <param name="applicantId"></param>
        /// <returns></returns>
        IList<Application> GetApplicationsByApplicant(int applicantId);


        /// Get application for given application id
        /// <param name="applicationId"></param>
        Application GetApplication(int aplicationId);


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

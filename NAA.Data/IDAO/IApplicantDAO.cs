using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NAA.Data.DAO;

namespace NAA.Data.IDAO
{
    public interface IApplicantDAO
    {
        /// <summary>
        /// Get list of applicants
        /// </summary>
        /// <returns></returns>
        IList<Applicant> GetApplicants();

        /// <summary>
        /// Get applicant for give applicant id
        /// </summary>
        /// <param name="ApplicantId"></param>
        /// <returns></returns>
       Applicant GetApplicant(int ApplicantId);

        Applicant GetApplicant(string userId);

       // Edit applicant method

       void EditApplicant(Applicant applicant);

        // ADD applicant method
       void AddApplicant(Applicant applicant);
    }
}

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
    public interface IApplicantService
    {
        /// Get list of applicants
        /// <returns></returns>
        IList<Applicant> GetApplicants();

        /// Return single applicant
        /// <param name="ApplicantId"></param>
        /// <returns></returns>
        Applicant GetApplicant(int ApplicantId);
        
        //Edit method
        void EditApplicant(Applicant applicant);

        //Add applicant method
        void AddApplicant(Applicant applicant);
    }
}

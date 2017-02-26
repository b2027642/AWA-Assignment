using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Services.IServices;
using NAA.Data;
//using NAA.Data.DAO;
//using NAA.Data.IDAO;


namespace NAA.Services.Service
{


    public class ApplicantService : IApplicantService
    {
        private NAA.Data.IDAO.IApplicantDAO _applicantDAO;

        public ApplicantService()
        {
            _applicantDAO = new NAA.Data.DAO.ApplicantDao();
        }
        
        // GET  MUSIC APPLICANTS IN A LIST FORMAT
        public IList<Applicant> GetApplicants()
        {
            return _applicantDAO.GetApplicants();
        }

        /// Return single applicant
        /// <param name="ApplicantId"></param>
        /// <returns></returns>
        public Applicant GetApplicant(int ApplicantId)
        {
            return _applicantDAO.GetApplicant(ApplicantId);
        }

        public Applicant GetApplicant(string userId)
        {
            return _applicantDAO.GetApplicant(userId);
        }

        //Edit method for applicant
        public void EditApplicant(Applicant applicant)
        {
            _applicantDAO.EditApplicant(applicant);
        }

        //Adding applicant method
        public void AddApplicant(Applicant applicant)
        {
            _applicantDAO.AddApplicant(applicant);
        }
    }

   
}

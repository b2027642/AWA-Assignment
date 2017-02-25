using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{

    public class ApplicantDao : IApplicantDAO
    {
        private readonly NAAEntities _context;
        public ApplicantDao()
        {
            _context = new NAAEntities();
        }

        public ApplicantDao(NAAEntities context)
        {
            _context = context;
        }

        /// Get list of applicants
        public IList<Applicant> GetApplicants()
        {
            var applicants = from applicant
                in _context.Applicant
                select applicant;

            return applicants.ToList();
        }

        /// Get applicant for give applicant id
        /// <param name="ApplicantId"></param>
        public Applicant GetApplicant(int applicantId)
        {
            var applicants = from applicant
                in _context.Applicant
                             where applicant.ApplicantId == applicantId
                             select applicant;
            return applicants.ToList<Applicant>().First();

        }

        //Edit public method

        public void EditApplicant(Applicant applicant)
        {
            Applicant profile = (from app
                                     in _context.Applicant
                                 where app.ApplicantId == applicant.ApplicantId
                                 select app).ToList<Applicant>().First();
            profile.ApplicantName = applicant.ApplicantName;
            profile.ApplicantAddress = applicant.ApplicantAddress;
            profile.Phone = applicant.Phone;
            profile.Email = applicant.Email;
            _context.SaveChanges();
        }


        //Add applicant method

        public void AddApplicant(Applicant applicant)
        {
            _context.Applicant.Add(applicant);
            _context.SaveChanges();
        }

    }

}

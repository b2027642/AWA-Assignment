using System;
using System.Collections.Generic;
using System.Linq;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        private readonly NAAEntities _context;
        private readonly IApplicantDAO _applicantDAO;
        private readonly IUniversityDAO _universityDAO;

        public ApplicationDAO()
        {
            _context = new NAAEntities();
            _applicantDAO = new ApplicantDao(_context);
            _universityDAO = new UniversityDAO(_context);
        }

        public ApplicationDAO(NAAEntities context)
        {
            _context = context;
            _applicantDAO = new ApplicantDao(_context);
            _universityDAO = new UniversityDAO(_context);
        }


        /// Get list of applications
  
        public IList<Application> GetApplications()
        {
            var applications = GetApplicationQueryable();
            return applications.ToList();
        }

        private IQueryable<Application> GetApplicationQueryable()
        {
            IQueryable<Application> applications = from application
                in _context.Application
                select application;
            return applications;
        }

        /// <summary>
        /// Get list of application for given university
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public IList<Application> GetApplications(int universityId)
        {
            IQueryable<Application> applications = GetApplicationQueryable().Where(x => x.UniversityId == universityId);

            return applications.ToList();
        }

        /// Get list of application for given applicant
        /// <param name="applicantId"></param>
        public IList<Application> GetApplicationsByApplicant(int applicantId)
        {
            IQueryable<Application> applications = GetApplicationQueryable().Where(x => x.ApplicantId == applicantId);

            return applications.ToList();
        }


        /// Get application for given application id
        /// <param name="applicationId"></param>
        public Application GetApplication(int applicationId)
        {
            IQueryable<Application> applications = from application
                in _context.Application
                where application.ApplicationId == applicationId
                select application;
                return applications.FirstOrDefault();
        }

        /// Edit application
        /// <param name="application"></param>
        public void EditApplication(Application application)
        {

            Application _application = (from app
                in _context.Application
                                        where app.ApplicationId == application.ApplicationId
                                        select app).FirstOrDefault();

            if (_application == null) throw new ApplicationException("Application doesnot exist");

            application.University = _universityDAO.GetUniversity(application.UniversityId);
            application.Applicant = _applicantDAO.GetApplicant(application.ApplicantId);
            _application.CourseName = application.CourseName.Trim();
            _application.PersonalStatement = application.PersonalStatement.Trim();
            _application.Firm = application.Firm;
            _application.TeacherContactDetails = application.TeacherContactDetails.Trim();
            _application.TeacherReference = application.TeacherReference.Trim();
            _application.UniversityOffer = application.UniversityOffer.Trim();
            _application.ApplicantId = application.ApplicantId;
            _application.UniversityId = application.UniversityId;

            _context.SaveChanges();
        }

        /// Add new application
        /// <param name="application"></param>
        public void AddApplication(Application application)
        {
            application.Applicant = _applicantDAO.GetApplicant(application.ApplicantId);
            application.University = _universityDAO.GetUniversity(application.UniversityId);

            _context.Application.Add(application);
            _context.SaveChanges();
        }

        /// Add new application or edit application
        /// <param name="application"></param>
        public void Save(Application application)
        {
            if (application.ApplicationId > 0)
            {
                EditApplication(application);
            }
            else
            {
                AddApplication(application);
            }
        }

        /// Delete application
        /// <param name="applicationId"></param>
        public void Delete(int applicationId)
        {
            var app = GetApplication(applicationId);
            _context.Application.Remove(app);
            _context.SaveChanges();
        }

        /// Update application status to accept offer
        /// <param name="applicationId"></param>
        public void Firm(int applicationId)
        {
            if (GetApplicationQueryable().Count(x => x.Firm == true) > 0)
            {
                throw new ApplicationException("You have already accepetd another offer");
            }

            var app = GetApplication(applicationId);

            app.Firm = true;

            _context.SaveChanges();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using NAA.Data;
using NAA.Services.IServices;

namespace NAA.Services.Service
{
    public class UniversityService : IUniversityService
    {
        private Data.IDAO.IUniversityDAO _universityDAO;

        public UniversityService()
        {
            _universityDAO = new Data.DAO.UniversityDAO();
        }

        /// Get university for given university id
        /// <param name="universityId"></param>
        /// 

        public University GetUniversity(int universityId)
        {
            var university = _universityDAO.GetUniversity(universityId);

            if (university != null)
            {
                university.UniversityName = university.UniversityName.Trim();
            }

            return university;
        }

        /// Get list of universities
        public IList<University> GetUniversities()
        {
            return _universityDAO.GetUniversities().Select(s => new University
            {
                UniversityName = s.UniversityName.Trim(),
                UniversityId = s.UniversityId
            }).ToList();
        }

        public void SaveUniversity(University university)
        {
            if (university.UniversityId > 0)
            {
                EditUniversity(university);
            }
            else
            {
                AddUniversity(university);
            }
        }

        public void EditUniversity(University university)
        {
              _universityDAO.EditUniversity(university);
        }

        public void AddUniversity(University university)
        {
            _universityDAO.AddUniversity(university);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
  public  class UniversityDAO: IUniversityDAO
    {
        private readonly NAAEntities _context;

        public UniversityDAO()
        {
            _context = new NAAEntities();
        }

        public UniversityDAO(NAAEntities context)
      {
          _context = context;
      }

      /// Get university for given university id
      /// <param name="universityId"></param>
      public University GetUniversity(int universityId)
      {
          var universities = from university
              in _context.University
              where university.UniversityId== universityId
              select university;

          return universities.ToList().FirstOrDefault();
      }

        /// Get university for given university name
        /// <param name="universityName"></param>
        public University GetUniversity(string universityName)
        {
            var universities = from university
                in _context.University
                               where university.UniversityName == universityName
                               select university;

            return universities.ToList().FirstOrDefault();
        }
        /// Get list of universities
        public IList<University> GetUniversities()
      {
            var universities = from university
               in _context.University select university;

          return universities.ToList();
      }

        //Edit public method

        public void EditUniversity(University university)
        {
            var uni = GetUniversity(university.UniversityName.Trim());

            if (uni != null && uni.UniversityId != university.UniversityId)
            {
                throw new ApplicationException("University with same name already exist.");
            }

            University dataUniversity = (from universities
              in _context.University
                                 where universities.UniversityId == university.UniversityId
                                 select universities).ToList().First();
           
            dataUniversity.UniversityName = university.UniversityName.Trim();
           
            _context.SaveChanges();
        }


        //Add applicant method

        public void AddUniversity(University university)
        {
            var uni = GetUniversity(university.UniversityName.Trim());

            if (uni != null)
            {
                throw new ApplicationException("University with same name already exist.");
            }

            University dataUniversity = (from universities
             in _context.University
                                         where universities.UniversityName == university.UniversityName
                                         select universities).ToList<University>().FirstOrDefault();

            if (dataUniversity == null)
            {
                _context.University.Add(university);
                _context.SaveChanges();
            }
        }
    }
}

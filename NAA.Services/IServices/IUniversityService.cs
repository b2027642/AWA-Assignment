using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IServices
{
   public interface IUniversityService
    {

        /// Get university for given university id
        /// <param name="universityId"></param>
        University GetUniversity(int universityId);
        
        /// Get list of universities
        IList<University> GetUniversities();

        //Edit method
        void EditUniversity(University university);
        
        //Edit
        void AddUniversity(University university);

        //Edit or add
       void SaveUniversity(University university);
    }
}

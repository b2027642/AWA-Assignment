using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
   public interface IUniversityDAO
   {
        /// Get university for given university id
        /// <param name="universityId"></param>
        University GetUniversity(int universityId);

        /// Get list of universities
        IList<University> GetUniversities();

       void AddUniversity(University university);
       void EditUniversity(University university);
   }
}

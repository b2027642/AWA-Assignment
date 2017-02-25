using System.Collections.Generic;

namespace NAA.Data.IDAO
{
    public interface IRoleDAO
    {
        /// Get list of applicants
        IList<AspNetRoles> GetRoles();
    }
}
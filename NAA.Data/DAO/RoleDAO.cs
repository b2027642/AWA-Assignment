using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
   public class RoleDAO : IRoleDAO
   {
        private readonly NAAEntities _context;
        public RoleDAO()
        {
            _context = new NAAEntities();
        }

        public RoleDAO(NAAEntities context)
        {
            _context = context;
        }

        /// Get list of applicants
        public IList<AspNetRoles> GetRoles()
        {
            var applicants = from aspNetRoles
                in _context.AspNetRoles
                             select aspNetRoles;

            return applicants.ToList();
        }
    }
}

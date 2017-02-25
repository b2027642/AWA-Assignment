using NAA.Data;
using System.Collections.Generic;
namespace NAA.Services.Service
{
    public class AdminService
    {
        private readonly NAA.Data.IDAO.IRoleDAO _roleDAO;

        public AdminService()
        {
            _roleDAO = new NAA.Data.DAO.RoleDAO();
        }

        // GET  Asp net roles
        public IList<AspNetRoles> GetApplicants()
        {
            return _roleDAO.GetRoles();
        }

        public void UpdateUserRole()
        {
            
        }
    }
}
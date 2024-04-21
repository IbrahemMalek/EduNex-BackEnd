//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EduNexDB.Entites.identity;

//namespace EduNexBL.Iservice
//{
//    public interface IAccountService
//    {
//        Task<ApplicationUser?> AddUser(UserDTO user, string roleName, int? SpecializationId);
//        Task<bool> UpdateUser(UserDTO userUpdated, int specialization);
//        Task<IList<ApplicationUser>> GetUsersInRole(string roleName);
//        Task<ApplicationUser?> GetUserInRoleById(string roleName, string id);
//        Task<ApplicationUser?> Login(LoginDto model);
//        Task<int> GetCount();
//        Task<bool> DeleteDoctor(string id);
//    }
//}

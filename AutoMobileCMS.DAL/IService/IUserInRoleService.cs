using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IUserInRoleService
    {
        IEnumerable<UserInRole> Get(Expression<Func<UserInRole, bool>> filter = null,
       Func<IQueryable<UserInRole>, IOrderedQueryable<UserInRole>> orderBy = null,
       string includeProperties = "");
        IEnumerable<UserInRole> GetAllUserInRoles();
        UserInRole GetUserInRoleById(int id);
        void Add(UserInRole role);
        void Update(UserInRole role);
        void Delete(int id);
        void SaveChanges();    
    }
}

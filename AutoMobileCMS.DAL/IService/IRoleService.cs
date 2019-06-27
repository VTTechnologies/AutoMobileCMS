using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IRoleService
    {
        IEnumerable<TblRole> Get(Expression<Func<TblRole, bool>> filter = null,
       Func<IQueryable<TblRole>, IOrderedQueryable<TblRole>> orderBy = null,
       string includeProperties = "");
        IEnumerable<TblRole> GetAllRoles();
        TblRole GetRoleById(int id);
        void Add(TblRole role);
        void Update(TblRole role);
        void Delete(int id);
        void SaveChanges();    
    }
}

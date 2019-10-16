using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IUserService
    {
        IEnumerable<TblUser> Get(Expression<Func<TblUser, bool>> filter = null,
       Func<IQueryable<TblUser>, IOrderedQueryable<TblUser>> orderBy = null,
       string includeProperties = "");
        IEnumerable<TblUser> GetAllUsers();
        TblUser GetUserById(int id);
        void Add(TblUser User);
        void Update(TblUser User);
        void Delete(int id);
        void SaveChanges();
        TblUser GetPassword(string userName);
    }
}

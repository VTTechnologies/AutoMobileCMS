using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IModelsService
    {
        IEnumerable<TblModel> Get(Expression<Func<TblModel, bool>> filter = null,
      Func<IQueryable<TblModel>, IOrderedQueryable<TblModel>> orderBy = null,
      string includeProperties = "");
        IEnumerable<TblModel> GetAllModels();
        TblModel GetModelById(int id);
        void Add(TblModel model);
        void Update(TblModel model);
        void Delete(int id);
        void SaveChanges();    
    }
}

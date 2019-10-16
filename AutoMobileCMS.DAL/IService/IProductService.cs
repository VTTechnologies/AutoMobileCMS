using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IProductService
    {
        IEnumerable<TblProduct> Get(Expression<Func<TblProduct, bool>> filter = null,
      Func<IQueryable<TblProduct>, IOrderedQueryable<TblProduct>> orderBy = null,
      string includeProperties = "");
        IEnumerable<TblProduct> GetAllProducts();
        TblProduct GetProductById(int id);
        void Add(TblProduct Product);
        void Update(TblProduct Product);
        void Delete(int id);
        void SaveChanges();    
    }
}

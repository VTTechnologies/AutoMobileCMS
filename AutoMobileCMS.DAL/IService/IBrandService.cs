using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IBrandService
    {
        IEnumerable<TblBrand> Get(Expression<Func<TblBrand, bool>> filter = null,
       Func<IQueryable<TblBrand>, IOrderedQueryable<TblBrand>> orderBy = null,
       string includeProperties = "");
        IEnumerable<TblBrand> GetAllBrands();
        TblBrand GetBrandById(int id);
        void Add(TblBrand brand);
        void Update(TblBrand brand);
        void Delete(int id);
        void SaveChanges();    
    }
}

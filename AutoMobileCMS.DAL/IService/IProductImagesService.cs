using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
    public interface IProductImagesService
    {
        IEnumerable<TblProductImage> Get(Expression<Func<TblProductImage, bool>> filter = null,
      Func<IQueryable<TblProductImage>, IOrderedQueryable<TblProductImage>> orderBy = null,
      string includeProperties = "");
        IEnumerable<TblProductImage> GetAllProductImages();
        TblProductImage GetProductImageById(int id);
        void Add(TblProductImage productimage);
        void Update(TblProductImage productimage);
        void Delete(int id);
        void SaveChanges();    
    }
}

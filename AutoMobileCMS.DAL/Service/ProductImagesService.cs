using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.DAL.Repository;
using AutoMobileCMS.DAL.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.Service
{
    public class ProductImagesService:IProductImagesService
    {
         private readonly AUTOMOBILECMSEntities2 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblProductImage> ProductImagesRepository;

        public ProductImagesService()
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            unitOfWork = new UnitOfWork(_dbContext);
            ProductImagesRepository = unitOfWork.GenericRepository<TblProductImage>();
        }
        public IEnumerable<TblProductImage> Get(Expression<Func<TblProductImage, bool>> filter = null,
       Func<IQueryable<TblProductImage>, IOrderedQueryable<TblProductImage>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblProductImage> productimages = ProductImagesRepository.Get(filter, orderBy, includeProperties).ToList();
            return productimages;
        }
        public void Delete(int id)
        {
            ProductImagesRepository.Delete(id);
        }

        public IEnumerable<TblProductImage> GetAllProductImages()
        {
            IEnumerable<TblProductImage> Allproductimages = ProductImagesRepository.GetAll().ToList();
            return Allproductimages;
        }

        public TblProductImage GetProductImageById(int id)
        {
            TblProductImage productimage = ProductImagesRepository.GetById(id);
            return productimage;
        }

        public void Add(TblProductImage productimage)
        {
            ProductImagesRepository.Add(productimage);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(TblProductImage productimage)
        {
            ProductImagesRepository.Update(productimage);
        }
    }
}

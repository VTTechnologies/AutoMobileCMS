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
    public class ProductService : IProductService
    {
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblProduct> ProductRepository;

        public ProductService()
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            unitOfWork = new UnitOfWork(_dbContext);
            ProductRepository = unitOfWork.GenericRepository<TblProduct>();
        }

        public IEnumerable<TblProduct> Get(Expression<Func<TblProduct, bool>> filter = null,
       Func<IQueryable<TblProduct>, IOrderedQueryable<TblProduct>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblProduct> products = ProductRepository.Get(filter, orderBy, includeProperties).ToList();
            return products;
        }
        public void Delete(int id)
        {
            ProductRepository.Delete(id);
        }
        public IEnumerable<TblProduct> GetAllProducts()
        {
            IEnumerable<TblProduct> Allproducts = ProductRepository.GetAll().ToList();
            return Allproducts;
        }

        public TblProduct GetProductById(int id)
        {
            TblProduct product = ProductRepository.GetById(id);
            return product;
        }

        public void Add(TblProduct product)
        {
            ProductRepository.Add(product);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
        public void Update(TblProduct product)
        {
            ProductRepository.Update(product);
        }

    }
}

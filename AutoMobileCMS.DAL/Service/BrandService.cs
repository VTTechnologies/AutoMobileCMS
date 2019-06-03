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
    public class BrandService: IBrandService
    {
        private readonly AUTOMOBILECMSEntities1 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblBrand> BrandRepository;

        public BrandService()
        {
            _dbContext = new AUTOMOBILECMSEntities1();
            unitOfWork = new UnitOfWork(_dbContext);
            BrandRepository = unitOfWork.GenericRepository<TblBrand>();
        }
        public IEnumerable<TblBrand> Get(Expression<Func<TblBrand, bool>> filter = null,
       Func<IQueryable<TblBrand>, IOrderedQueryable<TblBrand>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblBrand> brands = BrandRepository.Get(filter, orderBy, includeProperties).ToList();
            return brands;
        }
        public void Delete(int id)
        {
            BrandRepository.Delete(id);
        }

        public IEnumerable<TblBrand> GetAllBrands()
        {
            IEnumerable<TblBrand> Allbrands = BrandRepository.GetAll().ToList();
            return Allbrands;
        }

        public TblBrand GetBrandById(int id)
        {
            TblBrand brand = BrandRepository.GetById(id);
            return brand;
        }

        public void Add(TblBrand brand)
        {
            BrandRepository.Add(brand);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(TblBrand brand)
        {
            BrandRepository.Update(brand);
        }
    }

}

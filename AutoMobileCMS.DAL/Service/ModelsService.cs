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
    public class ModelsService : IModelsService
    {
        private readonly AUTOMOBILECMSEntities1 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblModel> ModelsRepository;

        public ModelsService()
        {
            _dbContext = new AUTOMOBILECMSEntities1();
            unitOfWork = new UnitOfWork(_dbContext);
            ModelsRepository = unitOfWork.GenericRepository<TblModel>();
        }

        public IEnumerable<TblModel> Get(Expression<Func<TblModel, bool>> filter = null,
       Func<IQueryable<TblModel>, IOrderedQueryable<TblModel>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblModel> models = ModelsRepository.Get(filter, orderBy, includeProperties).ToList();
            return models;
        }
        public void Delete(int id)
        {
            ModelsRepository.Delete(id);
        }
        public IEnumerable<TblModel> GetAllModels()
        {
            IEnumerable<TblModel> Allmodels = ModelsRepository.GetAll().ToList();
            return Allmodels;
        }

        public TblModel GetModelById(int id)
        {
            TblModel model = ModelsRepository.GetById(id);
            return model;
        }

        public void Add(TblModel model)
        {
            ModelsRepository.Add(model);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
        public void Update(TblModel model)
        {
            ModelsRepository.Update(model);
        }

    }
}

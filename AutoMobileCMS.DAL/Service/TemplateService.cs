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
    public class TemplateService : ITemplateService
    {
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<tblTemplate> TemplateRepository;

        public TemplateService()
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            unitOfWork = new UnitOfWork(_dbContext);
            TemplateRepository = unitOfWork.GenericRepository<tblTemplate>();
        }
        public IEnumerable<tblTemplate> Get(Expression<Func<tblTemplate, bool>> filter = null,
       Func<IQueryable<tblTemplate>, IOrderedQueryable<tblTemplate>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<tblTemplate> templates = TemplateRepository.Get(filter, orderBy, includeProperties).ToList();
            return templates;
        }
        public void Delete(int id)
        {
            TemplateRepository.Delete(id);
        }

        public IEnumerable<tblTemplate> GetAllTemplates()
        {
            IEnumerable<tblTemplate> Alltemplates = TemplateRepository.GetAll().ToList();
            return Alltemplates;
        }

        public tblTemplate GetTemplateById(int id)
        {
            tblTemplate Template = TemplateRepository.GetById(id);
            return Template;
        }

        public void Add(tblTemplate template)
        {
            TemplateRepository.Add(template);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(tblTemplate template)
        {
            TemplateRepository.Update(template);
        }
    }
}

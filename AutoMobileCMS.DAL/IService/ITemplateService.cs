using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.IService
{
   public interface ITemplateService
    {
       IEnumerable<tblTemplate> Get(Expression<Func<tblTemplate, bool>> filter = null,
       Func<IQueryable<tblTemplate>, IOrderedQueryable<tblTemplate>> orderBy = null,
       string includeProperties = "");
       IEnumerable<tblTemplate> GetAllTemplates();
       tblTemplate GetTemplateById(int id);
        void Add(tblTemplate template);
        void Update(tblTemplate template);
        void Delete(int id);
        void SaveChanges();    
    }
}

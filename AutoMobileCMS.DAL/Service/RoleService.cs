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
    public class RoleService : IRoleService
    {
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblRole> RoleRepository;

        public RoleService()
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            unitOfWork = new UnitOfWork(_dbContext);
            RoleRepository = unitOfWork.GenericRepository<TblRole>();
        }
        public IEnumerable<TblRole> Get(Expression<Func<TblRole, bool>> filter = null,
       Func<IQueryable<TblRole>, IOrderedQueryable<TblRole>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblRole> roles = RoleRepository.Get(filter, orderBy, includeProperties).ToList();
            return roles;
        }
        public void Delete(int id)
        {
            RoleRepository.Delete(id);
        }

        public IEnumerable<TblRole> GetAllRoles()
        {
            IEnumerable<TblRole> AllRoles = RoleRepository.GetAll().ToList();
            return AllRoles;
        }

        public TblRole GetRoleById(int id)
        {
            TblRole role = RoleRepository.GetById(id);
            return role;
        }

        public void Add(TblRole role)
        {
            RoleRepository.Add(role);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(TblRole role)
        {
            RoleRepository.Update(role);
        }
    }

}

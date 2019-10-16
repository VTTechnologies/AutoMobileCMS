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
    public class UserInRoleService : IUserInRoleService
    {
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<UserInRole> UserInRoleRepository;

        public UserInRoleService()
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            unitOfWork = new UnitOfWork(_dbContext);
            UserInRoleRepository = unitOfWork.GenericRepository<UserInRole>();
        }
        public IEnumerable<UserInRole> Get(Expression<Func<UserInRole, bool>> filter = null,
       Func<IQueryable<UserInRole>, IOrderedQueryable<UserInRole>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<UserInRole> roles = UserInRoleRepository.Get(filter, orderBy, includeProperties).ToList();
            return roles;
        }
        public void Delete(int id)
        {
            UserInRoleRepository.Delete(id);
        }

        public IEnumerable<UserInRole> GetAllUserInRoles()
        {
            IEnumerable<UserInRole> AllRoles = UserInRoleRepository.GetAll().ToList();
            return AllRoles;
        }

        public UserInRole GetUserInRoleById(int id)
        {
            UserInRole role = UserInRoleRepository.GetById(id);
            return role;
        }

        public void Add(UserInRole role)
        {
            UserInRoleRepository.Add(role);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(UserInRole role)
        {
            UserInRoleRepository.Update(role);
        }
    }

}

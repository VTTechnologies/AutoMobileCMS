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
    public class UserService: IUserService
    {
        private readonly AUTOMOBILECMSEntities1 _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TblUser> UserRepository;

        public UserService()
        {
            _dbContext = new AUTOMOBILECMSEntities1();
            unitOfWork = new UnitOfWork(_dbContext);
            UserRepository = unitOfWork.GenericRepository<TblUser>();
        }
        public IEnumerable<TblUser> Get(Expression<Func<TblUser, bool>> filter = null,
       Func<IQueryable<TblUser>, IOrderedQueryable<TblUser>> orderBy = null,
       string includeProperties = "")
        {
            IEnumerable<TblUser> users = UserRepository.Get(filter, orderBy, includeProperties).ToList();
            return users;
        }
        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }

        public IEnumerable<TblUser> GetAllUsers()
        {
            IEnumerable<TblUser> AllUSers = UserRepository.GetAll().ToList();
            return AllUSers;
        }

        public TblUser GetUserById(int id)
        {
            TblUser user = UserRepository.GetById(id);
            return user;
        }

        public void Add(TblUser user)
        {
            UserRepository.Add(user);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(TblUser user)
        {
            UserRepository.Update(user);
        }
    }

}

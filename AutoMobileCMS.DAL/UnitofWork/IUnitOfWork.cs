using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileCMS.DAL.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

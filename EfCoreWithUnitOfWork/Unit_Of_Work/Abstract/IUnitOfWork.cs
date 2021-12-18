using EfCoreWithUnitOfWork.DAL.Context;
using EfCoreWithUnitOfWork.DAL.Repositories;
using EfCoreWithUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWithUnitOfWork.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Product> ProductRepository { get; }
        int Complete();
    }
}

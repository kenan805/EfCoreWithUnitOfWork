using EfCoreWithUnitOfWork.DAL.Context;
using EfCoreWithUnitOfWork.DAL.Repositories;
using EfCoreWithUnitOfWork.DAL.Repositories.Concrete;
using EfCoreWithUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWithUnitOfWork.Unit_Of_Work.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _productContext;
        public IRepository<Category> CategoryRepository { get; private set; }
        public IRepository<Product> ProductRepository { get; private set; }

        public UnitOfWork(ProductContext productContext)
        {
            _productContext = productContext;
            CategoryRepository = new Repository<Category>(productContext);
            ProductRepository = new Repository<Product>(productContext);
        }


        public int Complete()
        {
            return _productContext.SaveChanges();
        }

        public void Dispose()
        {
            _productContext.Dispose();
        }
    }
}

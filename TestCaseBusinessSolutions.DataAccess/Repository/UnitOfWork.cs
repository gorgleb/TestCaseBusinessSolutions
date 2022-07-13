using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseBusinessSolutions.DataAccess.Data;
using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;

namespace TestCaseBusinessSolutions.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Provider = new ProviderRepository(_db);
            Order = new OrderRepository(_db);
        }

        public IProviderRepository Provider{ get; private set; }
        public IOrderRepository Order { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

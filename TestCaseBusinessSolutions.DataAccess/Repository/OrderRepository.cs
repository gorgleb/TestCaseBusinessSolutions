using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseBusinessSolutions.DataAccess.Data;
using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;
using TestCaseBusinessSolutions.Models;

namespace TestCaseBusinessSolutions.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Order obj)
        {
            _db.Orders.Update(obj);
        }
    }
}

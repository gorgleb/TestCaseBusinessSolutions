using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseBusinessSolutions.DataAccess.Data;
using TestCaseBusinessSolutions.Models;

namespace TestCaseBusinessSolutions.DataAccess.Repository
{
    public class ProviderRepository : Repository<Provider>,IProviderRepository
    {
        private ApplicationDbContext _db;
        public ProviderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Provider obj)
        {
            _db.Providers.Update(obj);
        }
    }
}

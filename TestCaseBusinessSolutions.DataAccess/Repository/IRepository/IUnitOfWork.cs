using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseBusinessSolutions.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProviderRepository Provider { get; }

        IOrderRepository Order { get; }
        public void Save();
    }
}

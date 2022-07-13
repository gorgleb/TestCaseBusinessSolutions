using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;
using TestCaseBusinessSolutions.Models;

public interface IProviderRepository : IRepository<Provider>
    {
        void Update(Provider obj);
    }
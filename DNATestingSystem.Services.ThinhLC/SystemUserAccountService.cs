using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.Models;

namespace DNATestingSystem.Services.ThinhLC
{
    public class SystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService()
            => _repository = new SystemUserAccountRepository();
        public Task<SystemUserAccount> GetSystemUserAccountAsync(string username, string password)
        {
            return _repository.GetSystemUserAccountAsync(username, password);
        }
    }
}

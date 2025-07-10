using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.ThinhLC
{
    public class ProfileThinhLCService : IProfileThinhLCService
    {
        private readonly ProfileThinhLCRepository _repository;

        public ProfileThinhLCService()
            => _repository = new ProfileThinhLCRepository();

        public async Task<List<ProfileThinhLc>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}

using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.ThinhLC
{
    public class SampleTypeThinhLCService : ISampleTypeThinhLCService
    {
        private readonly SampleTypeThinhLCRepository _repository;
        public SampleTypeThinhLCService()
            => _repository = new SampleTypeThinhLCRepository();

        public async Task<List<SampleTypeThinhLc>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SampleTypeThinhLc> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(SampleTypeThinhLc sampleType)
        {
            return await _repository.CreateAsync(sampleType);
        }

        public async Task<int> UpdateAsync(SampleTypeThinhLc sampleType)
        {
            return await _repository.UpdateAsync(sampleType);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var sampleType = await _repository.GetByIdAsync(id);
            return await _repository.RemoveAsync(sampleType);
        }
    }
}

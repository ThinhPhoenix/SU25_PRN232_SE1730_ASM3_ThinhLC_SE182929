using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.ModelExtensions;
using DNATestingSystem.Repository.ThinhLC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Azure.Core.HttpHeader;

namespace DNATestingSystem.Services.ThinhLC
{
    public class SampleThinhLCService : ISampleThinhLCService
    {
        private readonly SampleThinhLCRepository _repository;
        public SampleThinhLCService()
            => _repository = new SampleThinhLCRepository();
        public async Task<List<SampleThinhLc>> GetAllAsync()
            => await _repository.GetAllAsync();
        public async Task<SampleThinhLc> GetByIdAsync(int code)
            => await _repository.GetByIdAsync(code);
        public async Task<List<SampleThinhLc>> SearchAsync(int sampleId, string notes, string typeName)
            => await _repository.SearchAsync(sampleId, notes, typeName);
        public async Task<int> CreateAsync(SampleThinhLc sample)
            => await _repository.CreateAsync(sample);
        public async Task<int> UpdateAsync(SampleThinhLc sample)
            => await _repository.UpdateAsync(sample);
        public async Task<bool> RemoveAsync(int code)
        {
            var sample = await _repository.GetByIdAsync(code);
            return await _repository.RemoveAsync(sample);
        }
        public async Task<PaginationResult<List<SampleThinhLc>>> SearchWithPagingAsync(int sampleId, string notes, string typeName, int page, int pageSize)
        {
            var paginationResult = await _repository.SearchWithPagingAsync(sampleId, notes, typeName, page, pageSize);
            return paginationResult ?? new PaginationResult<List<SampleThinhLc>>();
        }

        public async Task<PaginationResult<List<SampleThinhLc>>> GetAllWithPagingAsync(int page, int pageSize)
        {
            var paginationResult = await _repository.GetAllWithPagingAsync(page, pageSize);
            return paginationResult ?? new PaginationResult<List<SampleThinhLc>>();
        }
    }
}

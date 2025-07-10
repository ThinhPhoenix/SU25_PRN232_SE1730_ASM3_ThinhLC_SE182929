using DNATestingSystem.Repository.ThinhLC.ModelExtensions;
using DNATestingSystem.Repository.ThinhLC.Models;

namespace DNATestingSystem.Services.ThinhLC
{
    public interface ISampleThinhLCService
    {
        Task<List<SampleThinhLc>> GetAllAsync();
        Task<SampleThinhLc> GetByIdAsync(int code);
        Task<List<SampleThinhLc>> SearchAsync(int sampleId, string notes, string typeName);
        Task<int> CreateAsync(SampleThinhLc sample);
        Task<int> UpdateAsync(SampleThinhLc sample);
        Task<bool> RemoveAsync(int code);
        Task<PaginationResult<List<SampleThinhLc>>> SearchWithPagingAsync(int sampleId, string notes, string typeName, int page, int pageSize);
        Task<PaginationResult<List<SampleThinhLc>>> GetAllWithPagingAsync(int page, int pageSize);
    }
}

using DNATestingSystem.Repository.ThinhLC.Basic;
using DNATestingSystem.Repository.ThinhLC.DBContext;
using DNATestingSystem.Repository.ThinhLC.ModelExtensions;
using DNATestingSystem.Repository.ThinhLC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC
{
    public class SampleThinhLCRepository : GenericRepository<SampleThinhLc>
    {
        public SampleThinhLCRepository() { }
        public SampleThinhLCRepository(Se18Prn232Se1730G3DnatestingSystemContext context) => _context = context;
        public async Task<List<SampleThinhLc>> GetAllAsync()
        {
            var samples = await _context.SampleThinhLcs
                .Include(s => s.SampleTypeThinhLc)
                .Include(s => s.ProfileThinhLc)
                .Include(s => s.AppointmentsTienDm)
                .ToListAsync();
            return samples ?? new List<SampleThinhLc>();
        }

        public async Task<SampleThinhLc> GetByIdAsync(int code)
        {
            var sample = await _context.SampleThinhLcs
                .Include(s => s.SampleTypeThinhLc)
                .Include(s => s.ProfileThinhLc)
                .Include(s => s.AppointmentsTienDm)
                .FirstOrDefaultAsync(s => s.SampleThinhLcid == code);
            return sample ?? new SampleThinhLc();
        }

        public async Task<List<SampleThinhLc>> SearchAsync(int sampleId, string notes, string typeName)
        {
            var samples = await _context.SampleThinhLcs
                .Include(s => s.SampleTypeThinhLc)
                .Include(s => s.ProfileThinhLc)
                .Include(s => s.AppointmentsTienDm)
                .Where(
                   s => s.Notes.Contains(notes) || string.IsNullOrEmpty(notes)
                && s.SampleTypeThinhLcid == sampleId || sampleId == 0 || sampleId == null
                && s.SampleTypeThinhLc.TypeName.Contains(typeName) || string.IsNullOrEmpty(typeName)
                )
                .ToListAsync();
            return samples ?? new List<SampleThinhLc>();
        }
        public async Task<PaginationResult<List<SampleThinhLc>>> SearchWithPagingAsync(int sampleId, string notes, string typeName, int page, int pageSize)
        {
            var samples = await _context.SampleThinhLcs
                .Include(s => s.SampleTypeThinhLc)
                .Where(
                   s => s.Notes.Contains(notes) || string.IsNullOrEmpty(notes)
                && s.SampleTypeThinhLcid == sampleId || sampleId == 0 || sampleId == null
                && s.SampleTypeThinhLc.TypeName.Contains(typeName) || string.IsNullOrEmpty(typeName)
                )
                .ToListAsync();
            var totalItems = samples.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            samples = samples.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginationResult<List<SampleThinhLc>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Items = samples
            };
            return result;
        }

        public async Task<PaginationResult<List<SampleThinhLc>>> SearchWithPagingAsync(SearchSampleThinhLCRequest searchRequest)
        {
            var samples = await this.SearchAsync(searchRequest.sampleId, searchRequest.notes, searchRequest.typeName);

            var totalItems = samples.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / searchRequest.PageSize.Value);

            samples = samples
                .Skip((searchRequest.CurrentPage.Value - 1) * searchRequest.PageSize.Value)
                .Take(searchRequest.PageSize.Value)
                .ToList();

            var result = new PaginationResult<List<SampleThinhLc>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = searchRequest.CurrentPage.Value,
                PageSize = searchRequest.PageSize.Value,
                Items = samples
            };
            return result;
        }

        public async Task<PaginationResult<List<SampleThinhLc>>> GetAllWithPagingAsync(int page, int pageSize)
        {
            var samples = await _context.SampleThinhLcs
                .Include(s => s.SampleTypeThinhLc)
                .ToListAsync();
            var totalItems = samples.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            samples = samples.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginationResult<List<SampleThinhLc>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Items = samples
            };
            return result;
        }
    }
}

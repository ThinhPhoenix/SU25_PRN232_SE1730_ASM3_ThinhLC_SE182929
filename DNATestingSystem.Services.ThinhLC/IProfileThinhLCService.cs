using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.ThinhLC
{
    public interface IProfileThinhLCService
    {
        Task<List<ProfileThinhLc>> GetAllAsync();
    }
}

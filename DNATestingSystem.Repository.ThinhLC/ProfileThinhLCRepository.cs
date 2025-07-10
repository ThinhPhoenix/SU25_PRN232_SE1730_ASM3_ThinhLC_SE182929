using DNATestingSystem.Repository.ThinhLC.Basic;
using DNATestingSystem.Repository.ThinhLC.DBContext;
using DNATestingSystem.Repository.ThinhLC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC
{
    public class ProfileThinhLCRepository : GenericRepository<ProfileThinhLc>
    {
        public ProfileThinhLCRepository() { }
        public ProfileThinhLCRepository(Se18Prn232Se1730G3DnatestingSystemContext context) => _context = context;
    }
}

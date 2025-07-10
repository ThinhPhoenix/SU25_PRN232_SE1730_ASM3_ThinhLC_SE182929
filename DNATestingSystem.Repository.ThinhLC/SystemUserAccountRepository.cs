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
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }
        public SystemUserAccountRepository(Se18Prn232Se1730G3DnatestingSystemContext context) => _context = context;

        public async Task<SystemUserAccount> GetSystemUserAccountAsync(string username, string password)
        {
            var account = await _context.SystemUserAccounts.FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);
            return account;
        }
    }
}

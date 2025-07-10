using DNATestingSystem.Repository.ThinhLC.Basic;
using DNATestingSystem.Repository.ThinhLC.DBContext;
using DNATestingSystem.Repository.ThinhLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC
{
    public class AppointmentsTienDMRepository : GenericRepository<AppointmentsTienDm>
    {
        public AppointmentsTienDMRepository() { }
        public AppointmentsTienDMRepository(Se18Prn232Se1730G3DnatestingSystemContext context) => _context = context;
    }
}

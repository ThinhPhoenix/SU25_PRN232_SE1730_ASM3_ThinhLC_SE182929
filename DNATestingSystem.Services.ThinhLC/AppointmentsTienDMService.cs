using DNATestingSystem.Repository.ThinhLC;
using DNATestingSystem.Repository.ThinhLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.ThinhLC
{
    public class AppointmentsTienDMService : IAppointmentsTienDMService
    {
        private readonly AppointmentsTienDMRepository _repository;
        public AppointmentsTienDMService()
            => _repository = new AppointmentsTienDMRepository();

        public async Task<List<AppointmentsTienDm>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}

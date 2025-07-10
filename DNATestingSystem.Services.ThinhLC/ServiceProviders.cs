using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.ThinhLC
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        ISampleThinhLCService SampleThinhLCService { get; }
        ISampleTypeThinhLCService SampleTypeThinhLCService { get; }
        IProfileThinhLCService ProfileThinhLCService { get; }
        IAppointmentsTienDMService AppointmentsTienDMService { get; }
    }
    
    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private ISampleThinhLCService _sampleThinhLCService;
        private ISampleTypeThinhLCService _sampleTypeThinhLCService;
        private IProfileThinhLCService _profileThinhLCService;
        private IAppointmentsTienDMService _appointmentsTienDMService;

        public ServiceProviders() { }

        public SystemUserAccountService UserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }
        
        public ISampleThinhLCService SampleThinhLCService
        {
            get { return _sampleThinhLCService ??= new SampleThinhLCService(); }
        }
        
        public ISampleTypeThinhLCService SampleTypeThinhLCService
        {
            get { return _sampleTypeThinhLCService ??= new SampleTypeThinhLCService(); }
        }
        
        public IProfileThinhLCService ProfileThinhLCService
        { 
            get { return _profileThinhLCService ??= new ProfileThinhLCService(); }
        }
        
        public IAppointmentsTienDMService AppointmentsTienDMService
        {
            get { return _appointmentsTienDMService ??= new AppointmentsTienDMService(); }
        }
    }
}
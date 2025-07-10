using DNATestingSystem.Repository.ThinhLC.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC
{
    public interface IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        SampleThinhLCRepository SampleThinhLCRepository { get; }
        SampleTypeThinhLCRepository SampleTypeThinhLCRepository { get; }
        ProfileThinhLCRepository ProfileThinhLCRepository { get; }
        AppointmentsTienDMRepository AppointmentsTienDMRepository { get; }
        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Se18Prn232Se1730G3DnatestingSystemContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private SampleThinhLCRepository _sampleThinhLCRepository;
        private SampleTypeThinhLCRepository _sampleTypeThinhLCRepository;
        private ProfileThinhLCRepository _profileThinhLCRepository;
        private AppointmentsTienDMRepository _appointmentsTienDMRepository;


    public UnitOfWork() => _context ??= new Se18Prn232Se1730G3DnatestingSystemContext();

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
        }
        public SampleThinhLCRepository SampleThinhLCRepository
        {
            get { return _sampleThinhLCRepository ??= new SampleThinhLCRepository(_context); }
        }
        public SampleTypeThinhLCRepository SampleTypeThinhLCRepository
        {
            get { return _sampleTypeThinhLCRepository ??= new SampleTypeThinhLCRepository(_context); }
        }
        public ProfileThinhLCRepository ProfileThinhLCRepository
        {
            get { return _profileThinhLCRepository ??= new ProfileThinhLCRepository(_context); }
        }
        public AppointmentsTienDMRepository AppointmentsTienDMRepository
        {
            get { return _appointmentsTienDMRepository ??= new AppointmentsTienDMRepository(_context); }
        }

        public void Dispose() => _context.Dispose();

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}

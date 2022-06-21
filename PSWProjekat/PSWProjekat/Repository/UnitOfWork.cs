using PSWProjekat.Models;
using System.Collections.Generic;
using PSWProjekat.Core;
using System;


namespace PSWProjekat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, dynamic> _repositories;
        private readonly ProjectContext _context;
        public IUserRepository Users { get; private set; }
        public IAppointmentRepository Appointments { get; set; }
        public IExaminationRepository Examinations { get; set; }
        public IFeedbackRepository Feedbacks { get; set; }
        public IHospitalRepository Hospitals { get; set; }
        public IMedicineRepository Medicines { get; set; }
        public IPharmacyRepository Phamracies { get; set; }
        public IPrescriptionRepository Prescriptions { get; set; }
        public IProcurementRepository Procruments { get; set; }
        public IRefferalRepository Refferals { get; set; }
        public IPrescriptionMedicineRepository PrescriptionMedicine { get; set; }

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Examinations = new ExaminationRepository(_context);
            Feedbacks = new FeedbackRepository(_context);
            Hospitals = new HospitalRepository(_context);
            Medicines = new MedicineRepository(_context);
            Phamracies = new PharmacyRepository(_context);
            Prescriptions = new PrescriptionRepository(_context);
            Procruments = new ProcurementRepository(_context);
            Refferals = new RefferalRepository(_context);
            PrescriptionMedicine = new PrescriptionMedicineRepository(_context);

        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }
            string type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }
            Type repositoryType = typeof(BaseRepository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return (IBaseRepository<TEntity>)_repositories[type];
        }
        public ProjectContext Context
        {
            get { return _context; }
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Repository;
using PSWProjekat.Service.Core;

namespace PSWProjekat.Service
{
    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public AppointmentService(ProjectConfiguration configuration, ILogger<AppointmentService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IEnumerable<Appointment> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))    
            {
                return unitOfWork.Appointments.GetAll();
            }
        }

        public IEnumerable<Appointment> GetAppointment(AppointmentDTO appointmentDTO)
        {
            DateTime date = DateTime.Parse(appointmentDTO.DateBegin);
            DateTime date2 = DateTime.Parse(appointmentDTO.DateEnd);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Appointments.GetAppointmentDoctorAndDate(appointmentDTO.Doctor, date, date2);
            }
        }

        public IEnumerable<Appointment> GetAppointmentDoctor(AppointmentDTO appointmentDTO)
        {
            DateTime date = DateTime.Parse(appointmentDTO.DateBegin);
            DateTime date2 = DateTime.Parse(appointmentDTO.DateEnd);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {

                return unitOfWork.Appointments.GetAppointmentDoctor(appointmentDTO.Doctor, date, date2);
            }
        }

        public IEnumerable<Appointment> GetAppointmentDate(AppointmentDTO appointmentDTO)
        {
            DateTime date = DateTime.Parse(appointmentDTO.DateBegin);
            DateTime date2 = DateTime.Parse(appointmentDTO.DateEnd);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))      
            {

                return unitOfWork.Appointments.GetAppointmentDate( date, date2);
            }
        }

        public IEnumerable<Appointment> GetAppointmentSpecialist()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Appointments.GetAppointmentSpecialist();
            }
        }


    }
}

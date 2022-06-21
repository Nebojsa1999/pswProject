using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;

namespace PSWProjekat.Service.Core
{
    public interface IAppointmentService : IBaseService<Appointment>
    {
        public IEnumerable<Appointment> getAll();
        public IEnumerable<Appointment> GetAppointment(AppointmentDTO appointmentDTO);
        public IEnumerable<Appointment> GetAppointmentDoctor(AppointmentDTO appointmentDTO);
        public IEnumerable<Appointment> GetAppointmentDate(AppointmentDTO appointmentDTO);
        public IEnumerable<Appointment> GetAppointmentSpecialist();



    }
}

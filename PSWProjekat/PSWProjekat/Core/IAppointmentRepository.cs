using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Core
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        public IEnumerable<Appointment> GetAppointmentDoctorAndDate(long doctor, DateTime dateStart, DateTime dateEnd);
        public IEnumerable<Appointment> GetAppointmentDoctor(long doctor, DateTime dateStart,DateTime dateEnd);
        public IEnumerable<Appointment> GetAppointmentDate(DateTime dateStart, DateTime dateEnd);
        public IEnumerable<Appointment> GetAppointmentSpecialist();


    }
}

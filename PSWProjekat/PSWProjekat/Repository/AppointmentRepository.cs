using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ProjectContext context) : base(context)
        {

        }

        public override IEnumerable<Appointment> GetAll()
        {
            return ProjectContext.Appointments.Include(x => x.UserDoctor).Include(x=> x.Hospital).ToList();
        }

        public override Appointment Get(long Id)
        {
            return ProjectContext.Appointments.Include(x => x.UserDoctor).Include(x => x.Hospital).ToList().Where(x => x.Id == Id).FirstOrDefault();
        }

           public IEnumerable<Appointment> GetAppointmentDoctorAndDate(long doctor, DateTime dateStart, DateTime dateEnd)
            {
                List<Appointment> list = new List<Appointment>();
                foreach (Entity entity in ProjectContext.Appointments.Where(x => x.UserDoctor.Id == doctor  && x.AppointmentDate.Date >= dateStart.Date && x.AppointmentDate.Date <= dateEnd.Date && x.AppointmentDate.Date >= DateTime.Now.Date).Include(x => x.UserDoctor).Include(x => x.Hospital).ToList())
                {
                    list.Add((Appointment)entity);
                }

                return list;
            }
        public IEnumerable<Appointment> GetAppointmentDoctor(long doctor,DateTime dateStart,DateTime dateEnd)
        {
            List<Appointment> list = new List<Appointment>();
            foreach (Entity entity in ProjectContext.Appointments.Where(x => x.UserDoctor.Id == doctor && x.AppointmentDate <= dateEnd.AddDays(10) && x.AppointmentDate >= dateStart.AddDays(-10) && x.AppointmentDate>DateTime.Now).Include(x=> x.Hospital).Include(x=> x.UserDoctor))
            {
                Console.WriteLine(dateEnd.AddDays(10));
                Console.WriteLine(dateStart.AddDays(-10));
                list.Add((Appointment)entity);
            }

            return list;
        }

        public IEnumerable<Appointment> GetAppointmentDate(DateTime dateStart, DateTime dateEnd)
        {
            List<Appointment> list = new List<Appointment>();
            foreach (Entity entity in ProjectContext.Appointments.Where(x => x.AppointmentDate.Date >= dateStart.Date && x.AppointmentDate.Date <= dateEnd.Date   && x.AppointmentDate>DateTime.Now).Include(x => x.Hospital).Include(x => x.UserDoctor))
            {
                list.Add((Appointment)entity);
            }

            return list;


        }

        public IEnumerable<Appointment> GetAppointmentSpecialist()
        {
            List<Appointment> appointmentSpecialists = new List<Appointment>();
            IEnumerable<Appointment> appointments =  ProjectContext.Appointments.Include(x => x.UserDoctor);
            foreach(Appointment appointment in appointments)
            {
                if(appointment.UserDoctor.UserType == Models.Enums.UserType.Doctor_Specialist)
                {
                    appointmentSpecialists.Add(appointment);
                }
            }
            return appointmentSpecialists;
        }
    }
    
}

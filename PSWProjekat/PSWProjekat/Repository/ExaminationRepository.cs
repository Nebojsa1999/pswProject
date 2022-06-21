using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class ExaminationRepository : BaseRepository<Examination>, IExaminationRepository
    {
        public ExaminationRepository(ProjectContext context) : base(context)
        {

        }

        public IEnumerable<Examination> GetAllExaminationPresentForUser(long id)
        {
            return ProjectContext.Examinations.Where(x => x.User.Id == id && x.Appointment.AppointmentDate >= DateTime.Now && x.Deleted == false).Include(x => x.Appointment.Hospital).Include(x=>x.Appointment.UserDoctor).ToList();
        }

        public IEnumerable<Examination> GetAllExaminationsPastForUser(long id)
        {
            return ProjectContext.Examinations.Where(x => x.User.Id == id && x.Appointment.AppointmentDate < DateTime.Now && x.Deleted == false).Include(x => x.Appointment.Hospital).Include(x => x.Appointment.UserDoctor).ToList();
        }

        public Examination GetExaminationBasedOnAppID(long appointment)
        {
            return ProjectContext.Examinations.Where(x => x.Appointment.Id == appointment).FirstOrDefault();

        }

        public Examination GetExamination(long id)
        {
            return ProjectContext.Examinations.Where(x => x.Id == id).Include(x => x.Appointment).FirstOrDefault();
        }
        public IEnumerable<Examination> GetExaminationsFromDoctor(long id)
        {
            return ProjectContext.Examinations.Where(x=> x.Deleted == false).Include(x => x.Appointment.UserDoctor).Include(x=> x.User).Where(x=>x.Appointment.UserDoctor.Id == id && x.Appointment.AppointmentDate.Date < DateTime.Now).ToList();
        }
    }
}

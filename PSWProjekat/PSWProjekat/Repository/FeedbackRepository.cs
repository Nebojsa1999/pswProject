using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(ProjectContext context) : base(context)
        {

        }

        public Feedback GetFeedBackBasedOnExam(long examination)
        {
            return ProjectContext.Feedbacks.Where(x => x.Examination.Id == examination).FirstOrDefault();

        }

        public  IEnumerable<Feedback> GetAllFeedbacks()
        {
            return ProjectContext.Feedbacks.Include(x => x.Examination).Include(x=> x.Examination.Appointment).Include(x=>x.Examination.User).Include(x=> x.Examination.Appointment.UserDoctor).ToList();
        }
        public IEnumerable<Feedback> GetAllApproved()
        {
            return ProjectContext.Feedbacks.Include(x => x.Examination).Include(x => x.Examination.Appointment).Include(x => x.Examination.User).Include(x => x.Examination.Appointment.UserDoctor).Where(x=> x.IsShown == true).ToList();
        }

    }
}

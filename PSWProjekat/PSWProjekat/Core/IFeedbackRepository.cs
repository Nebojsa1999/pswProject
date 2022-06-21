using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Core
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {
        public Feedback GetFeedBackBasedOnExam(long examination);
        public IEnumerable<Feedback> GetAllFeedbacks();
        public IEnumerable<Feedback> GetAllApproved();
    }
}

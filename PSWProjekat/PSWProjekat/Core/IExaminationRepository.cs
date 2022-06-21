using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Core
{
    public interface IExaminationRepository : IBaseRepository<Examination>
    {
        public Examination GetExaminationBasedOnAppID(long appointment);
        public IEnumerable<Examination> GetAllExaminationPresentForUser(long id);
        public IEnumerable<Examination> GetAllExaminationsPastForUser(long id);
        public Examination GetExamination(long id);
        public IEnumerable<Examination> GetExaminationsFromDoctor(long id);
    }
}

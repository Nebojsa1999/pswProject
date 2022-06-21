using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;

namespace PSWProjekat.Service.Core
{
    public interface IExaminationService : IBaseService<Examination>
    {
        public IEnumerable<Examination> GetAllExaminationPresentForUser(long id);
        public IEnumerable<Examination> GetAllExaminationPastForUser(long id);
        public Examination ScheduleExamination(ExaminationDTO entity);
        public bool Cancel(CancelDTO cancelDTO);
        public Examination ScheduleExaminationSpecialist(ExaminationSpecialistDTO entity);
        public IEnumerable<Examination> GetExaminationsFromDoctor(long doctorId);
    }
}

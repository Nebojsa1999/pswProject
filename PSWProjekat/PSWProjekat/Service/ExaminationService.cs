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
    public class ExaminationService : BaseService<Examination>, IExaminationService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public ExaminationService(ProjectConfiguration configuration, ILogger<ExaminationService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IEnumerable<Examination> GetAllExaminationPresentForUser(long id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))   
            {
                return unitOfWork.Examinations.GetAllExaminationPresentForUser(id);
            }
        }

        public IEnumerable<Examination> GetAllExaminationPastForUser(long id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Examinations.GetAllExaminationsPastForUser(id);
            }
        }

        public bool Cancel(CancelDTO cancelDTO)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                Examination examination = unitOfWork.Examinations.GetExamination(cancelDTO.id);
                if (examination.Appointment.AppointmentDate > DateTime.Now.Date.AddDays(2))
                {
                    examination.Appointment = null;
                    examination.Deleted = true;
                    User user = unitOfWork.Users.Get(cancelDTO.userId);
                    if(user.LastDateOfCancel.Date >= DateTime.Now.AddDays(30).Date)
                    {
                        user.CancelCount = 1;
                        user.LastDateOfCancel = DateTime.Now;
                        user.PotentialSpammer = false;
                        unitOfWork.Users.Update(user);
                        unitOfWork.Examinations.Update(examination);
                        _ = unitOfWork.Complete();
                        return true;


                    }
                    user.CancelCount += 1;
                    user.LastDateOfCancel = DateTime.Now;
                    if(user.CancelCount >= 3)
                    {
                        user.PotentialSpammer = true;
                        unitOfWork.Users.Update(user);
                        unitOfWork.Examinations.Update(examination);
                        _ = unitOfWork.Complete();
                        return true;

                    }
                    unitOfWork.Users.Update(user);
                    unitOfWork.Examinations.Update(examination);
                    _ = unitOfWork.Complete();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in ExaminationService in Cancel method {e.Message} in {e.StackTrace}");
                return false;
            }


        }

        public Examination ScheduleExamination(ExaminationDTO entity)
        {
            Examination examination = new Examination();
            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                if(unitOfWork.Examinations.GetExaminationBasedOnAppID(entity.appointmentId) != null) // da li postoji vec zakazan termin
                {
                    return null;
                }
                examination.DateCreated = DateTime.Now;
                examination.DateUpdated = DateTime.Now;
                examination.Appointment = unitOfWork.Appointments.Get(entity.appointmentId);
                examination.User = unitOfWork.Users.Get(entity.userId);
                unitOfWork.Examinations.Add(examination);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in ExaminationService in ScheduleExamination method {e.Message} in {e.StackTrace}");
                return null;
            }

            return examination;
        }

        public Examination ScheduleExaminationSpecialist(ExaminationSpecialistDTO entity)
        {
            Examination examination = new Examination();
            Refferal refferal = new Refferal();
            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                if (unitOfWork.Examinations.GetExaminationBasedOnAppID(entity.appointmentId) != null) // da li postoji vec zakazan termin
                {
                    return null;
                }
                examination.DateCreated = DateTime.Now;
                examination.DateUpdated = DateTime.Now;
                examination.Appointment = unitOfWork.Appointments.Get(entity.appointmentId);
                examination.User = unitOfWork.Users.Get(entity.userId);
                unitOfWork.Examinations.Add(examination);
                _ = unitOfWork.Complete();

                refferal.Reason = entity.reason;
                refferal.DateCreated = DateTime.Now;
                refferal.DateUpdated = DateTime.Now;
                refferal.RefferalTime = DateTime.Now;
                refferal.Examination = unitOfWork.Examinations.Get(examination.Id);
                unitOfWork.Refferals.Add(refferal);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in ExaminationService in ScheduleExamination method {e.Message} in {e.StackTrace}");
                return null;
            }

            return examination;
        }

        public IEnumerable<Examination> GetExaminationsFromDoctor(long doctorId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {

                return unitOfWork.Examinations.GetExaminationsFromDoctor(doctorId);

            }
        }

    }
}

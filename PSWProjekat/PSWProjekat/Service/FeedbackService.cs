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
using PSWProjekat.Util;

namespace PSWProjekat.Service
{
    public class FeedbackService : BaseService<Feedback>, IFeedbackService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public FeedbackService(ProjectConfiguration configuration, ILogger<FeedbackService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IEnumerable<Feedback> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Feedbacks.GetAllFeedbacks();
            }
        }

        public IEnumerable<Feedback> GetAllApproved()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Feedbacks.GetAllApproved();
            }
        }


        public Feedback GiveFeedBack(FeedBackDTO entity)
        {
            Feedback feedback = new Feedback();
            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                if (unitOfWork.Feedbacks.GetFeedBackBasedOnExam(entity.ExaminationId) != null) // da li postoji vec napravljen feedback za taj exam
                {
                    return null;
                }
                feedback.DateCreated = DateTime.Now;
                feedback.DateUpdated = DateTime.Now;
                feedback.Examination = unitOfWork.Examinations.Get(entity.ExaminationId);
                feedback.Annonimus = entity.Annonimus;
                feedback.Comment = entity.Comment;
                feedback.Deleted = false;
                feedback.Grade = EnumParse.gradeInt(entity.Grade);
                unitOfWork.Feedbacks.Add(feedback);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in FeedBackService in GiveFeedBack method {e.Message} in {e.StackTrace}");
                return null;
            }

            return feedback;
        }

        public bool ChangeFeedbackStatus(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                Feedback feedback = unitOfWork.Feedbacks.Get(id);
                if(feedback.IsShown == false)
                {
                    feedback.IsShown = true;
                    unitOfWork.Feedbacks.Update(feedback);
                    _ = unitOfWork.Complete();
                    return true;

                }
                else
                {
                    feedback.IsShown = false;
                    unitOfWork.Feedbacks.Update(feedback);
                    _ = unitOfWork.Complete();
                    return true;
                }          
              

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in FeedbackService in ChangeFeedbackStatus method {e.Message} in {e.StackTrace}");
                return false;
            }
        }


    }
}

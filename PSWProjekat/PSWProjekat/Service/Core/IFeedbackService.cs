using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;

namespace PSWProjekat.Service.Core
{
    public interface IFeedbackService
    {
        public IEnumerable<Feedback> getAll();
        public Feedback GiveFeedBack(FeedBackDTO entity);
        public IEnumerable<Feedback> GetAllApproved();
        public bool ChangeFeedbackStatus(long id);

    }
}

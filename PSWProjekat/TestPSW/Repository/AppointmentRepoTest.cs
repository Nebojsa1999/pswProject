using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Repository;

namespace TestPSW.Repository
{
    public class AppointmentRepoTest
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Appointment> appointment = unitOfWork.Appointments.GetAll() as List<Appointment>;
                Assert.AreEqual(appointment.Count, 1);

            }
        }
        [Test]

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Appointment appointment = unitOfWork.Appointments.Get(1);
                Assert.NotNull(appointment);

            }
        }
        [Test]

        public void TestScheduleAppointment()
        {
            long doctorID = 4;
            DateTime dateTime = new DateTime(2022, 3, 18);
            DateTime dateTime2 = new DateTime(2022, 3, 19);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                IEnumerable< Appointment> appointments = unitOfWork.Appointments.GetAppointmentDoctorAndDate(doctorID, dateTime, dateTime2);
                Assert.IsTrue(appointments.Count() != 0);

            }
        }
    }
}

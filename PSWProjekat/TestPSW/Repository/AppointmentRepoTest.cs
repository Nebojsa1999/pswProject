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
        Appointment entity = new Appointment();
        [SetUp]
        public void Setup()
        {
            entity.AppointmentDate = DateTime.Now;
            entity.AppointmentTime = new TimeSpan(10, 0, 0);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;
            entity.Deleted = false;
            
        }

        [Test]
        public void Test1()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Appointment> appointment = unitOfWork.Appointments.GetAll() as List<Appointment>;
                Assert.NotZero(appointment.Count());

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

        public void GetAppointmentDoctorAndDate()
        {
            long doctorID = 4;
            DateTime dateTime = new DateTime(2022, 6, 18);
            DateTime dateTime2 = new DateTime(2022, 7, 19);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                IEnumerable< Appointment> appointments = unitOfWork.Appointments.GetAppointmentDoctorAndDate(doctorID, dateTime, dateTime2);
                Assert.IsTrue(appointments.Count() != 0);

            }
        }

        [Test]

        public void GetAppointmentDate()
        {
            DateTime dateTime = new DateTime(2022, 6, 18);
            DateTime dateTime2 = new DateTime(2022, 7, 19);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                IEnumerable<Appointment> appointments = unitOfWork.Appointments.GetAppointmentDate( dateTime, dateTime2);
                Assert.IsTrue(appointments.Count() != 0);

            }
        }
        [Test]

        public void GetAppointmentDoctor()
        {
            long doctorId = 4;
            DateTime dateTime = new DateTime(2022, 6, 27);
            DateTime dateTime2 = new DateTime(2022, 6, 29);
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                IEnumerable<Appointment> appointments = unitOfWork.Appointments.GetAppointmentDoctor(doctorId,dateTime, dateTime2);
                Assert.IsTrue(appointments.Count() != 0);

            }
        }

        [Test]

        public void GetAppointmentSpecialist()
        {
         
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                IEnumerable<Appointment> appointments = unitOfWork.Appointments.GetAppointmentSpecialist();
                Assert.IsTrue(appointments.Count() != 0);

            }
        }

        [Test]

        public void CreateAppointment()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Hospital hospital = unitOfWork.Hospitals.Get(1);
                User doctor = unitOfWork.Users.Get(4);
                entity.Hospital = hospital;
                entity.UserDoctor = doctor;
                unitOfWork.Appointments.Add(entity);
                _ = unitOfWork.Complete();
                Assert.IsTrue(entity != null);

            }
        }

        [Test]

        public void CreateAppointmentSpecialist()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Hospital hospital = unitOfWork.Hospitals.Get(1);
                User doctor = unitOfWork.Users.Get(3);
                entity.Hospital = hospital;
                entity.UserDoctor = doctor;
                unitOfWork.Appointments.Add(entity);
                _ = unitOfWork.Complete();
                Assert.IsTrue(entity != null);

            }
        }
    }
}

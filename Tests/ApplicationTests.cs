using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ReHub.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        private ApplicationService _applicationService;

        [TestInitialize]
        public void Setup()
        {
            _applicationService = new ApplicationService();
        }

        /// <summary>
        /// Позитивный тест: создание новой заявки с корректными данными
        /// </summary>
        [TestMethod]
        public void CreateApplication_ValidData_ShouldReturnSuccess()
        {
            // Arrange
            int studentId = 1;
            int electiveId = 5;
            string studentName = "Иванов Иван";
            string electiveName = "Программирование на C#";

            // Act
            var application = _applicationService.CreateApplication(
                studentId,
                electiveId,
                studentName,
                electiveName);

            // Assert
            Assert.IsNotNull(application);
            Assert.AreEqual(studentId, application!.StudentId);
            Assert.AreEqual(electiveId, application.ElectiveId);
            Assert.AreEqual(studentName, application.StudentName);
            Assert.AreEqual(electiveName, application.ElectiveName);
            Assert.AreEqual("Ожидание", application.Status);
            Assert.IsTrue(application.ApplicationDate <= DateTime.Now);
        }

        /// <summary>
        /// Позитивный тест: принятие заявки преподавателем
        /// </summary>
        [TestMethod]
        public void ProcessApplication_Accept_ShouldUpdateStatusToAccepted()
        {
            // Arrange
            var application = _applicationService.CreateApplication(1, 5, "Иванов", "C#");
            int teacherId = 2;

            // Act
            _applicationService.ProcessApplication(application!, teacherId, "Принята");

            // Assert
            Assert.AreEqual("Принята", application!.Status);
            Assert.AreEqual(teacherId, application.CheckedBy);
        }

        /// <summary>
        /// Позитивный тест: отклонение заявки преподавателем
        /// </summary>
        [TestMethod]
        public void ProcessApplication_Reject_ShouldUpdateStatusToRejected()
        {
            // Arrange
            var application = _applicationService.CreateApplication(1, 5, "Иванов", "C#");
            int teacherId = 2;

            // Act
            _applicationService.ProcessApplication(application!, teacherId, "Отклонена");

            // Assert
            Assert.AreEqual("Отклонена", application!.Status);
            Assert.AreEqual(teacherId, application.CheckedBy);
        }

        /// <summary>
        /// Негативный тест: проверка повторной подачи заявки на тот же факультатив
        /// </summary>
        [TestMethod]
        public void CreateDuplicateApplication_ShouldReturnNull()
        {
            // Arrange
            int studentId = 1;
            int electiveId = 5;

            // Act
            var firstApp = _applicationService.CreateApplication(studentId, electiveId, "Иванов", "C#");
            var duplicateApp = _applicationService.CreateApplication(studentId, electiveId, "Иванов", "C#");

            // Assert
            Assert.IsNotNull(firstApp);
            Assert.IsNull(duplicateApp); // Должна быть блокировка повтора
        }

        /// <summary>
        /// Тест с ожидаемым исключением: попытка обработать несуществующую заявку
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessNullApplication_ShouldThrowException()
        {
            // Arrange
            Application? nullApp = null;

            // Act
            _applicationService.ProcessApplication(nullApp!, 2, "Принята");

            // Assert - ожидается исключение
        }

        /// <summary>
        /// Позитивный тест: получение заявок по ID студента
        /// </summary>
        [TestMethod]
        public void GetApplicationsByStudentId_ShouldReturnCorrectCount()
        {
            // Arrange
            _applicationService.CreateApplication(1, 1, "Иванов", "C#");
            _applicationService.CreateApplication(1, 2, "Иванов", "Python");
            _applicationService.CreateApplication(2, 1, "Петров", "C#");
            _applicationService.CreateApplication(3, 3, "Сидоров", "Java");

            // Act
            var studentApps = _applicationService.GetApplicationsByStudentId(1);

            // Assert
            Assert.AreEqual(2, studentApps.Count);
            Assert.IsTrue(studentApps.All(a => a.StudentId == 1));
        }

        /// <summary>
        /// Класс заявки для тестирования
        /// </summary>
        private class Application
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public int ElectiveId { get; set; }
            public string StudentName { get; set; } = string.Empty;
            public string ElectiveName { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public DateTime ApplicationDate { get; set; }
            public int? CheckedBy { get; set; }
        }

        /// <summary>
        /// Тест-заглушка для сервиса заявок
        /// </summary>
        private class ApplicationService
        {
            private List<Application> _applications = new List<Application>();

            public Application? CreateApplication(int studentId, int electiveId,
                string studentName, string electiveName)
            {
                // Проверка на дубликат
                if (_applications.Any(a => a.StudentId == studentId && a.ElectiveId == electiveId))
                    return null;

                var app = new Application
                {
                    Id = _applications.Count + 1,
                    StudentId = studentId,
                    ElectiveId = electiveId,
                    StudentName = studentName,
                    ElectiveName = electiveName,
                    Status = "Ожидание",
                    ApplicationDate = DateTime.Now
                };

                _applications.Add(app);
                return app;
            }

            public void ProcessApplication(Application application, int teacherId, string status)
            {
                if (application == null)
                    throw new ArgumentNullException(nameof(application));

                application.Status = status;
                application.CheckedBy = teacherId;
            }

            public List<Application> GetApplicationsByStudentId(int studentId)
            {
                return _applications.Where(a => a.StudentId == studentId).ToList();
            }
        }
    }
}
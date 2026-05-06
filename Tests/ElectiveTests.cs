using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ReHub.Tests
{
    [TestClass]
    public class ElectiveTests
    {
        private ElectiveService _electiveService;

        [TestInitialize]
        public void Setup()
        {
            _electiveService = new ElectiveService();
        }

        /// <summary>
        /// Позитивный тест: создание нового факультатива с корректными данными
        /// </summary>
        [TestMethod]
        public void CreateElective_ValidData_ShouldReturnSuccess()
        {
            // Arrange
            string name = "Программирование на C#";
            string description = "Основы языка C# и .NET";
            int teacherId = 2;
            int maxStudents = 25;

            // Act
            var elective = _electiveService.CreateElective(name, description, teacherId, maxStudents);

            // Assert
            Assert.IsNotNull(elective);
            Assert.AreEqual(name, elective!.Name);
            Assert.AreEqual(description, elective.Description);
            Assert.AreEqual(teacherId, elective.TeacherId);
            Assert.AreEqual(maxStudents, elective.MaxStudents);
            Assert.AreEqual("Активен", elective.Status);
            Assert.AreEqual(0, elective.CurrentStudents);
            Assert.IsTrue(elective.CreatedDate <= DateTime.Now);
        }

        /// <summary>
        /// Позитивный тест: проверка, что факультатив не полон, если студентов меньше максимума
        /// </summary>
        [TestMethod]
        public void IsElectiveAvailable_WhenCurrentLessThanMax_ShouldReturnTrue()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);

            // Устанавливаем текущее количество студентов меньше максимума
            elective.SetCurrentStudents(15);

            // Act
            bool isAvailable = elective.CurrentStudents < elective.MaxStudents;

            // Assert
            Assert.IsTrue(isAvailable);
        }

        /// <summary>
        /// Позитивный тест: проверка, что факультатив полон, если студентов равно максимуму
        /// </summary>
        [TestMethod]
        public void IsElectiveFull_WhenCurrentEqualsMax_ShouldReturnTrue()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);

            // Устанавливаем текущее количество студентов равным максимуму
            elective.SetCurrentStudents(20);

            // Act
            bool isFull = elective.CurrentStudents >= elective.MaxStudents;

            // Assert
            Assert.IsTrue(isFull);
        }

        /// <summary>
        /// Позитивный тест: проверка, что факультатив переполнен, если студентов больше максимума
        /// </summary>
        [TestMethod]
        public void IsElectiveOverfilled_WhenCurrentGreaterThanMax_ShouldReturnTrue()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);

            // Устанавливаем текущее количество студентов больше максимума
            elective.SetCurrentStudents(25);

            // Act
            bool isOverfilled = elective.CurrentStudents > elective.MaxStudents;

            // Assert
            Assert.IsTrue(isOverfilled);
        }

        /// <summary>
        /// Негативный тест: создание факультатива с пустым названием
        /// </summary>
        [TestMethod]
        public void CreateElective_WithEmptyName_ShouldReturnNull()
        {
            // Arrange
            string name = "";
            string description = "Описание";
            int teacherId = 1;
            int maxStudents = 20;

            // Act
            var elective = _electiveService.CreateElective(name, description, teacherId, maxStudents);

            // Assert
            Assert.IsNull(elective);
        }

        /// <summary>
        /// Негативный тест: создание факультатива с некорректным количеством студентов
        /// </summary>
        [TestMethod]
        public void CreateElective_WithInvalidMaxStudents_ShouldReturnNull()
        {
            // Arrange
            string name = "Тестовый";
            string description = "Описание";
            int teacherId = 1;
            int maxStudents = 0; // Неверное значение

            // Act
            var elective = _electiveService.CreateElective(name, description, teacherId, maxStudents);

            // Assert
            Assert.IsNull(elective);
        }

        /// <summary>
        /// Негативный тест: создание факультатива с несуществующим преподавателем
        /// </summary>
        [TestMethod]
        public void CreateElective_WithInvalidTeacherId_ShouldReturnNull()
        {
            // Arrange
            string name = "Тестовый";
            string description = "Описание";
            int teacherId = 999; // Несуществующий ID
            int maxStudents = 20;

            // Act
            var elective = _electiveService.CreateElective(name, description, teacherId, maxStudents);

            // Assert
            Assert.IsNull(elective);
        }

        /// <summary>
        /// Позитивный тест: обновление статуса факультатива
        /// </summary>
        [TestMethod]
        public void UpdateElectiveStatus_ShouldChangeStatus()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);

            // Act
            elective.Status = "Завершен";

            // Assert
            Assert.AreEqual("Завершен", elective.Status);
        }

        /// <summary>
        /// Позитивный тест: увеличение количества студентов при зачислении
        /// </summary>
        [TestMethod]
        public void AddStudent_ShouldIncreaseCurrentStudents()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);
            int initialCount = elective.CurrentStudents;

            // Act
            elective.AddStudent();

            // Assert
            Assert.AreEqual(initialCount + 1, elective.CurrentStudents);
        }

        /// <summary>
        /// Позитивный тест: уменьшение количества студентов при отчислении
        /// </summary>
        [TestMethod]
        public void RemoveStudent_ShouldDecreaseCurrentStudents()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);
            elective.AddStudent(); // Добавляем студента
            elective.AddStudent(); // Добавляем ещё одного
            int countAfterAdd = elective.CurrentStudents;

            // Act
            elective.RemoveStudent();

            // Assert
            Assert.AreEqual(countAfterAdd - 1, elective.CurrentStudents);
        }

        /// <summary>
        /// Негативный тест: попытка удалить студента, когда их нет
        /// </summary>
        [TestMethod]
        public void RemoveStudent_WhenNoStudents_ShouldNotChangeCount()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 20);
            int initialCount = elective.CurrentStudents;

            // Act
            elective.RemoveStudent();

            // Assert
            Assert.AreEqual(initialCount, elective.CurrentStudents); // Количество не должно стать отрицательным
        }

        /// <summary>
        /// Тест с ожидаемым исключением: попытка добавить студента в полный факультатив
        /// </summary>
        [TestMethod]
        public void AddStudent_WhenElectiveFull_ShouldThrowException()
        {
            // Arrange
            var elective = _electiveService.CreateElective("Тестовый", "Описание", 1, 2);
            elective.AddStudent(); // 1-й студент
            elective.AddStudent(); // 2-й студент (достигнут максимум)

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                elective.AddStudent(); // Попытка добавить 3-го студента
            });
        }

        /// <summary>
        /// Позитивный тест: получение списка всех факультативов
        /// </summary>
        [TestMethod]
        public void GetAllElectives_ShouldReturnAllElectives()
        {
            // Arrange
            _electiveService.CreateElective("C#", "Описание 1", 1, 20);
            _electiveService.CreateElective("Python", "Описание 2", 1, 15);
            _electiveService.CreateElective("Java", "Описание 3", 2, 25);

            // Act
            var allElectives = _electiveService.GetAllElectives();

            // Assert
            Assert.AreEqual(3, allElectives.Count);
        }

        /// <summary>
        /// Позитивный тест: получение факультативов по ID преподавателя
        /// </summary>
        [TestMethod]
        public void GetElectivesByTeacherId_ShouldReturnCorrectCount()
        {
            // Arrange
            _electiveService.CreateElective("C#", "Описание 1", 1, 20);
            _electiveService.CreateElective("Python", "Описание 2", 1, 15);
            _electiveService.CreateElective("Java", "Описание 3", 2, 25);
            _electiveService.CreateElective("JavaScript", "Описание 4", 1, 30);

            // Act
            var teacherElectives = _electiveService.GetElectivesByTeacherId(1);

            // Assert
            Assert.AreEqual(3, teacherElectives.Count);
            Assert.IsTrue(teacherElectives.All(e => e.TeacherId == 1));
        }

        /// <summary>
        /// Позитивный тест: поиск факультатива по названию
        /// </summary>
        [TestMethod]
        public void FindElectiveByName_ShouldReturnMatchingElectives()
        {
            // Arrange
            _electiveService.CreateElective("Программирование на C#", "Описание 1", 1, 20);
            _electiveService.CreateElective("Программирование на Python", "Описание 2", 1, 15);
            _electiveService.CreateElective("Базы данных", "Описание 3", 2, 25);

            // Act
            var found = _electiveService.FindElectivesByName("Программирование");

            // Assert
            Assert.AreEqual(2, found.Count);
            Assert.IsTrue(found.All(e => e.Name.Contains("Программирование")));
        }

        /// <summary>
        /// Класс факультатива для тестирования
        /// </summary>
        private class Elective
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int TeacherId { get; set; }
            public string TeacherName { get; set; } = string.Empty;
            public int MaxStudents { get; set; }
            public int CurrentStudents { get; private set; }
            public string Status { get; set; } = string.Empty;
            public DateTime CreatedDate { get; set; }

            public void SetCurrentStudents(int count)
            {
                CurrentStudents = count;
            }

            public void AddStudent()
            {
                if (CurrentStudents >= MaxStudents)
                    throw new InvalidOperationException("Факультатив уже полон");

                CurrentStudents++;
            }

            public void RemoveStudent()
            {
                if (CurrentStudents > 0)
                    CurrentStudents--;
            }
        }

        /// <summary>
        /// Тест-заглушка для сервиса факультативов
        /// </summary>
        private class ElectiveService
        {
            private List<Elective> _electives = new List<Elective>();
            private List<int> _validTeacherIds = new List<int> { 1, 2, 3 }; // Имитация существующих преподавателей

            public Elective? CreateElective(string name, string description, int teacherId, int maxStudents)
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(name))
                    return null;

                if (maxStudents < 1 || maxStudents > 100)
                    return null;

                if (!_validTeacherIds.Contains(teacherId))
                    return null;

                var elective = new Elective
                {
                    Id = _electives.Count + 1,
                    Name = name,
                    Description = description,
                    TeacherId = teacherId,
                    MaxStudents = maxStudents,
                    Status = "Активен",
                    CreatedDate = DateTime.Now
                };

                _electives.Add(elective);
                return elective;
            }

            public List<Elective> GetAllElectives()
            {
                return _electives.ToList();
            }

            public List<Elective> GetElectivesByTeacherId(int teacherId)
            {
                return _electives.Where(e => e.TeacherId == teacherId).ToList();
            }

            public List<Elective> FindElectivesByName(string searchTerm)
            {
                return _electives.Where(e => e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
    }
}
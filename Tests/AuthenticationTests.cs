using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReHub.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        private TestUserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _userService = new TestUserService();
        }

        /// <summary>
        /// Позитивный тест: проверка входа администратора с правильными данными
        /// </summary>
        [TestMethod]
        public void Login_AdminWithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            string login = "admin";
            string password = "admin123";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Admin", role);
        }

        /// <summary>
        /// Позитивный тест: проверка входа преподавателя с правильными данными
        /// </summary>
        [TestMethod]
        public void Login_TeacherWithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            string login = "teacher1";
            string password = "teacher123";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Teacher", role);
        }

        /// <summary>
        /// Позитивный тест: проверка входа студента с правильными данными
        /// </summary>
        [TestMethod]
        public void Login_StudentWithValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            string login = "student1";
            string password = "student123";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Student", role);
        }

        /// <summary>
        /// Негативный тест: проверка входа с неверным паролем
        /// </summary>
        [TestMethod]
        public void Login_WithInvalidPassword_ShouldReturnFalse()
        {
            // Arrange
            string login = "admin";
            string password = "wrongpassword";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(role);
        }

        /// <summary>
        /// Негативный тест: проверка входа с несуществующим логином
        /// </summary>
        [TestMethod]
        public void Login_WithNonExistentLogin_ShouldReturnFalse()
        {
            // Arrange
            string login = "unknown";
            string password = "anypassword";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(role);
        }

        /// <summary>
        /// Негативный тест: проверка входа с пустыми данными
        /// </summary>
        [TestMethod]
        public void Login_WithEmptyCredentials_ShouldReturnFalse()
        {
            // Arrange
            string login = "";
            string password = "";

            // Act
            bool result = _userService.ValidateUser(login, password, out string? role);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(role);
        }

        /// <summary>
        /// Тест-заглушка для сервиса пользователей (имитация БД)
        /// </summary>
        private class TestUserService
        {
            public bool ValidateUser(string login, string password, out string? role)
            {
                role = null;

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                    return false;

                // Имитация проверки в БД
                if (login == "admin" && password == "admin123")
                {
                    role = "Admin";
                    return true;
                }
                if (login == "teacher1" && password == "teacher123")
                {
                    role = "Teacher";
                    return true;
                }
                if (login == "student1" && password == "student123")
                {
                    role = "Student";
                    return true;
                }

                return false;
            }
        }
    }
}
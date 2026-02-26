using System;

namespace ReHub
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Administrator
    {
        public int AdminId { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Elective
    {
        public int ElectiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int MaxStudents { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LessonDate { get; set; }
        public string LessonTime { get; set; }
    }

    public class Application1
    {
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public int ElectiveId { get; set; }
        public string StudentName { get; set; }
        public string ElectiveName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public int? ReviewerId { get; set; }
    }
}
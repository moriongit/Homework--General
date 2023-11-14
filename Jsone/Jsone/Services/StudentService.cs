using Jsone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsone.Services
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(string code)
        {
            var studentToRemove = students.Find(s => s.Code == code);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }

        public void EditStudent(string code, Student student)
        {
            var existingStudent = students.Find(s => s.Code == code);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Surname = student.Surname;
                existingStudent.Code = student.Code;
            }
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}

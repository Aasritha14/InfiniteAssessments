using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StudentService : MarshalByRefObject, IStudentService
    {
        private Dictionary<int, Student> students = new Dictionary<int, Student>
        {
            { 1, new Student { Id = 1, Name = "Ram", Class = "10th", TotalMarks = 450 } },
            { 2, new Student { Id = 2, Name = "Mohit", Class = "11th", TotalMarks = 200 } },
            { 3, new Student { Id = 3, Name = "Pooja", Class = "9th", TotalMarks = 320 } }
        };

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students.Values);
        }

        public Student GetStudent(int id)
        {
            if (id == 0)
                return new Student { Id = 0, Name = "Default", Class = "N/A", TotalMarks = 0 };

            if (students.TryGetValue(id, out var student))
            {
                if (student.TotalMarks < 300)
                    throw new Exception($"Marks less than 300 for {student.Name}");
                return student;
            }

            return new Student { Id = 0, Name = "Not Found", Class = "N/A", TotalMarks = 0 };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int TotalMarks { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Class: {Class}, Total Marks: {TotalMarks}";
    }

    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
    }

}

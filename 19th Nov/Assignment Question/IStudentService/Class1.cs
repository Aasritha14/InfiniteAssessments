using StudentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IStudentLib
{
    public interface IStudentService
    {
        void ShowAllStudents();
        Task<Student> GetStudentAsync(int id);
    }
}

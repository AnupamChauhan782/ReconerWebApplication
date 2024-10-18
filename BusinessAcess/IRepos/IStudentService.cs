using ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcess.IRepos
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task  AddNewstudent(Student student);
        Task Deletestudent(int studentId);
        Task<Student> GetStudentById(int studentId);
        Task UpdateStudent(Student student);
    }
}

using ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcess.IRepos
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeacher();
        Task  AddNewTeacher(Teacher teacher);
        Task DeleteTeacher(int id);
        Task<Teacher> GetTeacherById(int id);
        Task UpadateTeacher(Teacher teacher);
    }
}

using BusinessAcess.IRepos;
using DataAccess.DbContect;
using Microsoft.EntityFrameworkCore;
using ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcess.Repos
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDBConect _dbConect;
        public TeacherService(ApplicationDBConect applicationDB)
        {
            this._dbConect = applicationDB;
        }
        public async Task AddNewTeacher(Teacher teacher)
        {
            if (teacher == null) throw new ArgumentNullException("Not Valid Data");
            await _dbConect.ReTeacher_table.AddAsync(teacher);
            await _dbConect.SaveChangesAsync();
        }

        public async Task DeleteTeacher(int id)
        {
              var teachData=await _dbConect.ReTeacher_table.FirstOrDefaultAsync(x=>x.Teach_Id==id);
            if (teachData == null) throw new Exception("Not Found");
            _dbConect.ReTeacher_table.Remove(teachData);
            await _dbConect.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeacher()
        {
            var teachers = await _dbConect.ReTeacher_table.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
             var GetByIdTechData=await _dbConect.ReTeacher_table.FirstOrDefaultAsync(x=>x.Teach_Id == id);
            if(GetByIdTechData == null)
            {
                throw new Exception("Not find this data");
            }
            return GetByIdTechData;
        }

        public async Task UpadateTeacher(Teacher teacher)
        {
            var res=await _dbConect.ReTeacher_table.FirstOrDefaultAsync(x=>x.Teach_Id==teacher.Teach_Id);
            if(res == null)
            {
                throw new Exception("Not found this Id");
            }
            res.Teacher_Name = teacher.Teacher_Name;
            res.Address = teacher.Address;
            res.Salary = teacher.Salary;
            res.Subject = teacher.Subject;
            res.FirstBell = teacher.FirstBell;
            res.Contact = teacher.Contact;
            res.Gender = teacher.Gender;
            res.Section = teacher.Section;
             _dbConect.ReTeacher_table.Update(res);
            await _dbConect.SaveChangesAsync();
        }
    }
}

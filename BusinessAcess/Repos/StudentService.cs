using BusinessAcess.IRepos;
using DataAccess.DbContect;
using Microsoft.EntityFrameworkCore;
using ModelData.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcess.Repos
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDBConect _connection;

        public StudentService(ApplicationDBConect connection)
        {
            this._connection = connection; 
        }
        public async Task AddNewstudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("Model is not valid");
            await _connection.ReStudent_table.AddAsync(student);
            await _connection.SaveChangesAsync();   
           
        }

        public async Task Deletestudent(int studentId)
        {
           var student=await _connection.ReStudent_table.FirstOrDefaultAsync(x=>x.StudId==studentId);
            if (student == null) throw new ArgumentNullException("not found");
             _connection.ReStudent_table.Remove(student);
            await _connection.SaveChangesAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            var student = await _connection.ReStudent_table.FirstOrDefaultAsync(x=>x.StudId==studentId);

            if (student == null)
            {
                // Instead of throwing an exception, return null or handle the error
                return null;
            }

            return student;
        }


        public async Task<List<Student>> GetStudents()
        {
            var students = await _connection.ReStudent_table.ToListAsync();
            return students;
        }

        public async Task UpdateStudent(Student student)
        {
            // Find the student by ID in the database
            var res = await _connection.ReStudent_table.FirstOrDefaultAsync(x => x.StudId == student.StudId);

            if (res == null)
            {
                // If student is not found, throw an exception or handle the error gracefully
                throw new ArgumentNullException(nameof(student), "Student not found");
            }

            // Update the properties of the student entity
            res.Name = student.Name;
            res.Address = student.Address;
            res.EmailAddress = student.EmailAddress;
            res.AnnualFess = student.AnnualFess;
            res.Contact = student.Contact;
            res.DOB = student.DOB;
            res.Section = student.Section;
            res.Stream = student.Stream;

            // Mark the entity as modified
            _connection.ReStudent_table.Update(res);  // We should update `res`, not `student`

            // Save the changes to the database
            await _connection.SaveChangesAsync();
        }

    }
}

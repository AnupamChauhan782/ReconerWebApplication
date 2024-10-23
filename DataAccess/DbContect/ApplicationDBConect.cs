using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DataAccess.DbContect
{
    public class ApplicationDBConect:IdentityDbContext
    {
        public ApplicationDBConect(DbContextOptions<ApplicationDBConect> dbContextOptions):base(dbContextOptions) 
        {
            
        }
       public DbSet<Student> ReStudent_table { get; set; }
       public DbSet<Book> ReBook_table { get; set; }
       public DbSet<Teacher> ReTeacher_table { get; set; }

    }
}

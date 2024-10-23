using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Models
{
    public class Teacher
    {
        [Key]
        public int Teach_Id { get; set; }
        [Required,StringLength(50)]
        public string Teacher_Name { get; set; }
        [Required(ErrorMessage ="Enter Address!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter ContactNum!")]
        [MaxLength(10)]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Enter Gender!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter FirstBell!")]
        public string FirstBell{ get; set; }
        [Required(ErrorMessage = "Enter Sections!")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Enter Salary!")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Enter Subject!")]
        public string Subject { get; set; }
    }
}

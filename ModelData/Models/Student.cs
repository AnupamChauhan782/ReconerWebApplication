using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        [Required(ErrorMessage ="Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public Double Contact { get; set; }
        public int? AnnualFess { get; set; }
        public string DOB { get; set; }
        [Required]
        public string Stream { get; set; }
        [Required(ErrorMessage ="Enter Section ")]
        public string Section { get; set; }
    
    }
}

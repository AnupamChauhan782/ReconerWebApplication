using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.ViewModel
{
    public class RegistarViewM
    {
        [Required(ErrorMessage ="Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="Password and confirm password not matched!")]
        [Required(ErrorMessage ="Plz confirm the password")]
        public string ConfirmPassword { get; set; }
    }
}

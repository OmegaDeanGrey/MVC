using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace Liberation.Models
{
public class LoginModel
    
    
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password{ get; set; }
         [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberation.Models
{
public class RegisterModel
    
    
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password{ get; set; }
        [Required]
        public required string Firstname{ get; set; }
        [Required]
        public required string Lastname{ get; set; }
        public required string Email{ get; set; }
    }
}
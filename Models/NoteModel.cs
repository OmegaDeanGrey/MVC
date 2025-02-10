using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberation.Models
{
     [Table("NoteModels")]
public class NoteModel
    
    
    {
        public required int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]

        public string? Note { get; set; }
    }
}
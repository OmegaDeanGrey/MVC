using System.ComponentModel.DataAnnotations;


namespace Liberation.Models


{
    public class PokemonDetail
    {
        public int Id { get; set; }
         [Required]
        public string? Name { get; set; }
        // Add other properties as needed
    }
}

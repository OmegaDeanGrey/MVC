using System.ComponentModel.DataAnnotations;

namespace Liberation.Models
{
    public class PokemonDetail
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public float Height { get; set; }
        
        public float Weight { get; set; }
        
        public string Url { get; set; }

        public Sprites PokemonSprites { get; set; }

        public class Sprites
        {
            public string Front_default { get; set; }
        }

        // Constructor to initialize nested properties
        public PokemonDetail()
        {
            PokemonSprites = new Sprites();
        }
    }
}

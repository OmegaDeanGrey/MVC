using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liberation.Models
{
    public class LiberationDbContext : DbContext
    {
        public LiberationDbContext(DbContextOptions<LiberationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NoteModel> Notes { get; set; }
    }
}

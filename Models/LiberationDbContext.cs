using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Liberation.Models
{
    public class LiberationDbContext : IdentityDbContext<IdentityUser>
    {
        public LiberationDbContext(DbContextOptions<LiberationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NoteModel> Notes { get; set; }

    }
}

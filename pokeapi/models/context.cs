using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace pokeapi.models
{
    public class context:IdentityDbContext<Applicationuser>
    {
        public context(DbContextOptions options) :base(options)
        { 
        }
        public DbSet<category> categories { get; set; }
        public DbSet<pokemon> pokemons { get; set; }
        public DbSet<owner> owners { get; set; }
        public DbSet<country> country { get; set; }
        public DbSet<review> reviews { get; set; }
        public DbSet<reviewer> reviewers { get; set; }
    }
}

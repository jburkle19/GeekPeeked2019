using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GeekPeeked.Models
{
    public class GeekPeekedDbContext : IdentityDbContext<ApplicationUser>
    {
        public GeekPeekedDbContext()
            : base("SqlConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<Contest> Contests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Nominee> Nominees { get; set; }
        
        //public DbSet<ContestEntry> ContestEntries { get; set; }
        //public DbSet<ContestCategorySelection> ContestCategorySelections { get; set; }

        public static GeekPeekedDbContext Create()
        {
            return new GeekPeekedDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
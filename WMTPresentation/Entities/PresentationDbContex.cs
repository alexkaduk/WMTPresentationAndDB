using Microsoft.EntityFrameworkCore;

namespace WMTPresentation.Entities
{
    public class PresentationDbContex : DbContext
    {
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Slide> Slides { get; set; }

        //public DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PresentationDb");
        }
    }
}

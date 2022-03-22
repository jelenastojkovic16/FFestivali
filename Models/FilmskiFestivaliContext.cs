using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Models{

    public class FilmskiFestivaliContext : DbContext{
        public DbSet<Festival> Festivali { get; set; }
        public DbSet<Film> Filmovi {get;set;}
        public DbSet<DnevniRepertoar> DnevniRepertoari {get;set;}
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }

        public FilmskiFestivaliContext(DbContextOptions option) : base(option){

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }

}
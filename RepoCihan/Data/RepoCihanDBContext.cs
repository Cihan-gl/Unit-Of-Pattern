using Microsoft.EntityFrameworkCore;
using RepoCihan.Model;

namespace RepoCihan.Data
{
    public class RepoCihanDBContext : DbContext
    {
        public RepoCihanDBContext(DbContextOptions<RepoCihanDBContext> options) : base(options) { }

        public DbSet<Personel> Personeller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasData(
                                    new Personel { Id = Guid.NewGuid(), AdıveİkinciAdı = "Cihan", Soyadı = "Güler", Telefon = "05352223344", Eposta = "cihan@guler.com" },
                                    new Personel { Id = Guid.NewGuid(), AdıveİkinciAdı = "Paşa", Soyadı = "Gülmez", Telefon = "05341118977", Eposta = "cihan@gulmez.com" }
                                                 );

        }

    }
}

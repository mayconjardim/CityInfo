using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {

        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointOfInterests { get; set; }

       public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
               new City("Rio de Janeiro")
               {
                   Id = 1,
                   Description = "A cidade maravilhosa."
               },
               new City("Niteroi")
               {
                   Id = 2,
                   Description = "A cidade tropical"
               },
               new City("São Paulo")
               {
                   Id = 3,
                   Description = "A cidade que nunca para."
               });

            modelBuilder.Entity<PointOfInterest>()
             .HasData(
               new PointOfInterest("Cristo Redentor")
               {
                   Id = 1,
                   CityId = 1,
                   Description = "Uma das sete maravilhas do mundo."
               },
               new PointOfInterest("Lapa")
               {
                   Id = 2,
                   CityId = 1,
                   Description = "Onde você encontra todas as tribos."
               },
                 new PointOfInterest("Praia de Itacoatiara.")
                 {
                     Id = 3,
                     CityId = 2,
                     Description = "Praia para Surfistas"
                 },
               new PointOfInterest("Pedra do Elefante")
               {
                   Id = 4,
                   CityId = 2,
                   Description = "Pra quem gosta de trilhas."
               },
               new PointOfInterest("Praça da Sé.")
               {
                   Id = 5,
                   CityId = 3,
                   Description = "Uma grande praça aberta"
               },
               new PointOfInterest("Rua 15 de Março")
               {
                   Id = 6,
                   CityId = 3,
                   Description = "Onde você pode comprar tudo."
               }
               );
            base.OnModelCreating(modelBuilder);
        }
    }
}

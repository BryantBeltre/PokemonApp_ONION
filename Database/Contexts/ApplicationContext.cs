using Microsoft.EntityFrameworkCore;
using Pokemons.Core.Domain.Common;
using Pokemons.Core.Domain.Enities;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokemons.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Tipo> Tipo { get; set; }

        public DbSet<User> users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreateBy = "The young king";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastMoifiedBy = "The young king";
                        break;
                }                    
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            #region tablas
            modelBuilder.Entity<Pokemon>()
                .ToTable("Pokemons");

            modelBuilder.Entity<Region>()
                .ToTable("Regions");

            modelBuilder.Entity<Tipo>()
                .ToTable("Type");

            modelBuilder.Entity<User>()
                .ToTable("Users");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Pokemon>()
                .HasKey(pokemons => pokemons.Id);

            modelBuilder.Entity<Region>()
                .HasKey(region => region.Id);

            modelBuilder.Entity<Tipo>()
                .HasKey(tipo => tipo.Id);

            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            #endregion

            #region "RelationShips"
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(region => region.Pokemons)
                .WithOne(pokemons => pokemons.region)
                .HasForeignKey(pokemon => pokemon.IdRegion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemon>(region => region.pokemons)
                .WithOne(pokemons => pokemons.Tipo)
                .HasForeignKey(pokemon => pokemon.IdTipo)
                .OnDelete(DeleteBehavior.Cascade);
    
            modelBuilder.Entity<User>()
                .HasMany<Pokemon>(user => user.pokemons)
                .WithOne(pokemons => pokemons.user)
                .HasForeignKey(pokemon => pokemon.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region "Popety Configuration"


            #region pokemons
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired();
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.UrlImg)
                .IsRequired();

            #endregion


            #region region
            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired();
            #endregion


            #region tipo
            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Name)
                .IsRequired();
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(user => user.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Phone)
                .IsRequired();             
            #endregion


            #endregion

        }

    }
}

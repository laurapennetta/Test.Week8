using FinalFantasy.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinalFantasy.RepositoryEF
{
    public class Context : DbContext
    {
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Arma> Armi { get; set; }
        public DbSet<Eroe> Eroi { get; set; }
        public DbSet<Mostro> Mostri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = Game; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Gamer>(new GamerConfiguration());
            modelBuilder.ApplyConfiguration<Arma>(new ArmaConfiguration());
            modelBuilder.ApplyConfiguration<Eroe>(new EroeConfiguration());
            modelBuilder.ApplyConfiguration<Mostro>(new MostroConfiguration());
        }
    }
}

using FinalFantasy.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class EroeConfiguration : IEntityTypeConfiguration<Eroe>
    {
        public void Configure(EntityTypeBuilder<Eroe> builder)
        {
            builder.ToTable("Eroe");
            builder.HasKey(k => k.ID);
            builder.Property("Nome");
            builder.Property(l => l.Livello).HasColumnType("int").IsRequired();
            builder.HasOne(a => a.Arma).WithMany(p => p.Eroi)
                                       .HasForeignKey(f => f.NomeArma);
            builder.Property(c => c.Categoria).IsRequired();
            builder.Property(pl => pl.PuntiLivello).HasColumnType("int").IsRequired();
            builder.HasData(
                new Eroe() {
                    ID = 1,
                    Nome = "Furetto con il Fioretto",
                    Livello = 1,
                    NomeArma = "Spada",
                    Categoria = CategoriaEroe.Soldier,
                    PuntiLivello = 20,
                    NickNameGamer = "Laura_Pennetta"
                },
                new Eroe() {
                    ID = 2,
                    Nome = "Bisoretta",
                    Livello = 2,
                    NomeArma = "Bacchetta",
                    Categoria = CategoriaEroe.Wizard,
                    PuntiLivello = 33,
                    NickNameGamer = "Laura_Pennetta"
                },
                new Eroe() {
                    ID = 3,
                    Nome = "Uccellino Malandrino",
                    Livello = 3,
                    NomeArma = "Ascia",
                    Categoria = CategoriaEroe.Soldier,
                    PuntiLivello = 65,
                    NickNameGamer = "Laura_Pennetta"
                },
                new Eroe() {
                    ID = 4,
                    Nome = "Il gatto con gli stivali",
                    Livello = 4,
                    NomeArma = "Mazza",
                    Categoria = CategoriaEroe.Soldier,
                    PuntiLivello = 99,
                    NickNameGamer = "Laura_Pennetta"
                },
                new Eroe() {
                    ID = 5,
                    Nome = "Fiona",
                    Livello = 5,
                    NomeArma = "Arco e frecce",
                    Categoria = CategoriaEroe.Wizard,
                    PuntiLivello = 130,
                    NickNameGamer = "Laura_Pennetta"
                });
        }
    }
}

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
    public class MostroConfiguration : IEntityTypeConfiguration<Mostro>
    {
        public void Configure(EntityTypeBuilder<Mostro> builder)
        {
            builder.ToTable("Mostro");
            builder.HasKey(k => k.ID);
            builder.Property("Nome");
            builder.Property(l => l.Livello).HasColumnType("int").IsRequired();
            builder.HasOne(a => a.Arma).WithMany(p => p.Mostri)
                                       .HasForeignKey(f => f.NomeArma);
            builder.Property(c => c.Categoria).IsRequired();
            builder.HasData(
                new Mostro { ID = 1, Nome = "Pollo Agguerrito", Livello = 1, NomeArma = "Clava", Categoria = CategoriaMostro.Ghost },
                new Mostro { ID = 2, Nome = "Gallinella Urlante", Livello = 2, NomeArma = "Tempesta", Categoria = CategoriaMostro.Lucifer },
                new Mostro { ID = 3, Nome = "Fantasma Formaggino", Livello = 3, NomeArma = "Arco", Categoria = CategoriaMostro.Ghost },
                new Mostro { ID = 4, Nome = "Lupo MangiaFrutta", Livello = 4, NomeArma = "Fulmine", Categoria = CategoriaMostro.Lucifer },
                new Mostro { ID = 5, Nome = "LucifeRutto", Livello = 5, NomeArma = "Divinazione", Categoria = CategoriaMostro.Lucifer });
        }
    }
}

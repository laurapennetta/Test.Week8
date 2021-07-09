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
    public class ArmaConfiguration : IEntityTypeConfiguration<Arma>
    {
        public void Configure(EntityTypeBuilder<Arma> builder)
        {
            builder.ToTable("Arma");
            builder.HasKey(k => k.Nome);
            builder.Property(pd => pd.PuntiDanno).HasColumnType("int").IsRequired();
            builder.HasData(
                new Arma { Nome = "Ascia", PuntiDanno = 8 },
                new Arma { Nome = "Mazza", PuntiDanno = 5 },
                new Arma { Nome = "Spada", PuntiDanno = 10 },
                new Arma { Nome = "Arco e frecce", PuntiDanno = 8 },
                new Arma { Nome = "Bacchetta", PuntiDanno = 5 },
                new Arma { Nome = "Bastone Magico", PuntiDanno = 10 },
                new Arma { Nome = "Arco", PuntiDanno = 7 },
                new Arma { Nome = "Clava", PuntiDanno = 5 },
                new Arma { Nome = "Divinazione", PuntiDanno = 15 },
                new Arma { Nome = "Fulmine", PuntiDanno = 10 },
                new Arma { Nome = "Tempesta", PuntiDanno = 8 });
        }
    }
}

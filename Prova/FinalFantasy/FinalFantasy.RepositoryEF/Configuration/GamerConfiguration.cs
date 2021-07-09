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
    public class GamerConfiguration : IEntityTypeConfiguration<Gamer>
    {
        public void Configure(EntityTypeBuilder<Gamer> builder)
        {
            builder.ToTable("Gamer");
            builder.HasKey(k => k.NickName);
            builder.HasMany(e => e.Eroi).WithOne(g => g.Gamer)
                                        .HasForeignKey(f => f.NickNameGamer);
            builder.HasData(
                new Gamer() { 
                NickName = "Laura_Pennetta" });
        }
    }
}

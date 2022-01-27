using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Data.Maps
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Matricula);
            builder.Property(c => c.Pasep);
            builder.Property(c => c.DataCad)
                .IsRequired();
            builder.Property(c => c.Situacao)
                .IsRequired();
            builder.HasOne(c => c.Cargo)
                .WithMany(x => x.Colaboradores);
        }
    }
}

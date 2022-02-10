using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Data.Maps
{
    public class AssuntoAtendimentoMap : IEntityTypeConfiguration<AssuntoAtendimento>
    {
        public void Configure(EntityTypeBuilder<AssuntoAtendimento> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.TituloAssunto)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        
        }
    }
}

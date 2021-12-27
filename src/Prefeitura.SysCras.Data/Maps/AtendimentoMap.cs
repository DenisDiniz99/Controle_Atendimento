using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Data.Maps
{
    public class AtendimentoMap : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DataAtend)
                .IsRequired();
            builder.Property(a => a.HoraAtend)
                .IsRequired();
            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(a => a.Protocolo)
                .IsRequired();
            builder.Property(a => a.TipoAtendimento)
                .IsRequired();
            builder.Property(a => a.StatusAtendimento)
                .IsRequired();
            builder.HasOne(a => a.AssuntoAtendimento)
                .WithMany(x => x.Atendimentos);
            builder.HasOne(a => a.Colaborador)
                .WithMany(x => x.Atendimentos);
            builder.HasOne(a => a.Cidadao)
                .WithMany(x => x.Atendimentos);

        }
    }
}

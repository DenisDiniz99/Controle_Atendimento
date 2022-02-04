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

            builder.Property(a => a.UsuarioId)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(a => a.Descricao)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(500);

            builder.OwnsOne(a => a.Protocolo, protocolo =>
            {
                protocolo.Property(p => p.NumProtocolo)
                    .IsRequired();
            });

            builder.Property(a => a.StatusAtendimento)
                .IsRequired();

            builder.Property(a => a.Observacao)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.HasOne(a => a.TipoAtendimento)
                .WithMany(x => x.Atendimentos);

            builder.HasOne(a => a.AssuntoAtendimento)
                .WithMany(x => x.Atendimentos);

            builder.HasOne(a => a.Cidadao)
                .WithMany(x => x.Atendimentos);
        }
    }
}

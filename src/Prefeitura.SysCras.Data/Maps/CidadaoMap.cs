using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prefeitura.SysCras.Data.Maps
{
    public class CidadaoMap : IEntityTypeConfiguration<Cidadao>
    {
        public void Configure(EntityTypeBuilder<Cidadao> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Cpf)
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(c => c.Rg)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.Sexo)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(c => c.TelefoneFixo)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.Celular)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.DataNasc)
                .IsRequired();
            builder.Property(c => c.DataCad)
                .IsRequired();
            builder.OwnsOne(s => s.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua).IsRequired();
                endereco.Property(e => e.Numero).IsRequired();
                endereco.Property(e => e.Bairro).IsRequired();
                endereco.Property(e => e.Cidade).IsRequired();
                endereco.Property(e => e.Cep).IsRequired();
                endereco.Property(e => e.Estado).IsRequired();
            });
        }
    }
}

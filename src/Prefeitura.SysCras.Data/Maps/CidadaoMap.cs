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
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.NomeSocial)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(c => c.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(c => c.Rg)
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.Nis)
                .HasColumnType("varchar")
                .HasMaxLength(30);
            builder.Property(c => c.TituloEleitor)
                .HasColumnType("int");
            builder.Property(c => c.Nacionalidade)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(c => c.Naturalidade)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(c => c.EstadoCivil)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Genero)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Raca)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.NumFilhos)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();
            builder.Property(c => c.TelefoneFixo)
                .HasColumnType("varchar")
                .HasMaxLength(15);
            builder.Property(c => c.Celular)
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.DataNasc)
                .IsRequired();
            builder.Property(c => c.DataCad)
                .IsRequired();
            builder.Property(c => c.Situacao)
                .IsRequired();
            builder.Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.OwnsOne(c => c.Filiacao, filiacao => 
            {
                filiacao.Property(f => f.NomePai)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
                filiacao.Property(f => f.NomeMae)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            });
            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();
                endereco.Property(e => e.Numero)
                    .HasColumnType("varchar")
                    .HasMaxLength(10)
                    .IsRequired();
                endereco.Property(e => e.Bairro)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();
                endereco.Property(e => e.Cidade)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();
                endereco.Property(e => e.Cep)
                    .HasColumnType("varchar")
                    .HasMaxLength(8)
                    .IsRequired();
                endereco.Property(e => e.Estado)
                    .HasColumnType("varchar")
                    .HasMaxLength(2)
                    .IsRequired();
            });
        }
    }
}

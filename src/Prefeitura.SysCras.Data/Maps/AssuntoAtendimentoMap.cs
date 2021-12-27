using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prefeitura.SysCras.Data.Maps
{
    public class AssuntoAtendimentoMap : IEntityTypeConfiguration<AssuntoAtendimento>
    {
        public void Configure(EntityTypeBuilder<AssuntoAtendimento> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.TituloAssunto)
                .HasMaxLength(50)
                .IsRequired();
        
        }
    }
}

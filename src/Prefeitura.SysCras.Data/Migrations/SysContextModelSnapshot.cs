﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Migrations
{
    [DbContext(typeof(SysContext))]
    partial class SysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloAssunto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AssuntoAtendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Atendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssuntoAtendimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CidadaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHoraAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Protocolo")
                        .HasColumnType("int");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("int");

                    b.Property<Guid>("TipoAtendimentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoAtendimentoId");

                    b.HasIndex("CidadaoId");

                    b.HasIndex("TipoAtendimentoId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataCad")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Naturalidade")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nis")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeSocial")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("NumFilhos")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Raca")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("Situacao")
                        .HasColumnType("bit");

                    b.Property<string>("TelefoneFixo")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("TituloEleitor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cidadaos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.TipoAtendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposAtendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Atendimento", b =>
                {
                    b.HasOne("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", "AssuntoAtendimento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("AssuntoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prefeitura.SysCras.Business.Entities.Cidadao", "Cidadao")
                        .WithMany("Atendimentos")
                        .HasForeignKey("CidadaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prefeitura.SysCras.Business.Entities.TipoAtendimento", "TipoAtendimento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("TipoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssuntoAtendimento");

                    b.Navigation("Cidadao");

                    b.Navigation("TipoAtendimento");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.OwnsOne("Prefeitura.SysCras.Business.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("CidadaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("varchar(8)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("CidadaoId");

                            b1.ToTable("Cidadaos");

                            b1.WithOwner()
                                .HasForeignKey("CidadaoId");
                        });

                    b.OwnsOne("Prefeitura.SysCras.Business.ValueObjects.Filiacao", "Filiacao", b1 =>
                        {
                            b1.Property<Guid>("CidadaoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NomeMae")
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("NomePai")
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("CidadaoId");

                            b1.ToTable("Cidadaos");

                            b1.WithOwner()
                                .HasForeignKey("CidadaoId");
                        });

                    b.Navigation("Endereco");

                    b.Navigation("Filiacao");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.AssuntoAtendimento", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.Cidadao", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Prefeitura.SysCras.Business.Entities.TipoAtendimento", b =>
                {
                    b.Navigation("Atendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}

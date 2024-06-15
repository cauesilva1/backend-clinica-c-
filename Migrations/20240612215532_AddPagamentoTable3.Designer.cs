﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using teste.Data;

#nullable disable

namespace teste.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240612215532_AddPagamentoTable3")]
    partial class AddPagamentoTable3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("teste.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("id_agendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id_agendamento"));

                    b.Property<string>("Cpf_Cliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HorarioAgendado")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("cod_procedimento")
                        .HasColumnType("int");

                    b.Property<DateTime>("horario_agendamento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("id_profissional")
                        .HasColumnType("int");

                    b.HasKey("id_agendamento");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("teste.Models.ClienteModel", b =>
                {
                    b.Property<string>("Cpf_Cliente")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "Cpf_Cliente");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Complemento");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Logradouro");

                    b.Property<string>("Nome_Cliente")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Nome_Cliente");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "Numero");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Telefone");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "Uf");

                    b.HasKey("Cpf_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("teste.Models.PagamentoModel", b =>
                {
                    b.Property<int>("id_pagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id_pagamento"));

                    b.Property<string>("Cpf_Cliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorPago")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("data_pagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("forma_pagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("id_agendamento")
                        .HasColumnType("int");

                    b.HasKey("id_pagamento");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("teste.Models.ProcedimentoModel", b =>
                {
                    b.Property<int>("cod_procedimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("cod_procedimento"));

                    b.Property<string>("procedimento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("cod_procedimento");

                    b.ToTable("procedimentos");
                });

            modelBuilder.Entity("teste.Models.ProfissionalModel", b =>
                {
                    b.Property<int>("id_profissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id_profissional"));

                    b.Property<string>("especialidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome_profissional")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id_profissional");

                    b.ToTable("profissionais");
                });
#pragma warning restore 612, 618
        }
    }
}

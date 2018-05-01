﻿// <auto-generated />
using Fiap.ProjetoFifa2018.Dominio.Enums;
using Fiap.ProjetoFifa2018.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Fiap.ProjetoFifa2018.Persistencia.Migrations
{
    [DbContext(typeof(CopaContexto))]
    partial class CopaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas.GolsDaPartida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<int>("IdDoJogadorQueMarcou");

                    b.Property<int>("IdDoTimeQueMarcou");

                    b.Property<string>("NomeDoJogadorQueMarcou")
                        .IsRequired();

                    b.Property<int?>("PartidaId")
                        .IsRequired();

                    b.Property<int>("TempoDoGolEmMinutos");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.ToTable("GolsDasPartidas");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<DateTime>("DataDaPartida");

                    b.Property<int>("IdDoTimeMandante");

                    b.Property<int?>("IdDoTimeVencedor")
                        .IsRequired();

                    b.Property<int>("IdDoTimeVisitante");

                    b.Property<string>("NomeDoTimeMandante")
                        .IsRequired();

                    b.Property<string>("NomeDoTimeVisitante")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Times.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<string>("Escudo")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("NomeDoTime")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("TorneioId");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Playoffs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<int>("IdDaPartidaDeIda");

                    b.Property<int?>("IdDaPartidaDeVolta")
                        .IsRequired();

                    b.Property<int?>("IdDoTimeVencedor")
                        .IsRequired();

                    b.Property<int>("Nivel");

                    b.HasKey("Id");

                    b.ToTable("Playoffs");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.TimeDoGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<int>("Derrotas");

                    b.Property<int>("Empates");

                    b.Property<int>("GolsMarcados");

                    b.Property<int>("GolsSofridos");

                    b.Property<int?>("GrupoId");

                    b.Property<int>("IdDoTime");

                    b.Property<string>("NomeDoTime")
                        .IsRequired();

                    b.Property<int>("PontuacaoAtual");

                    b.Property<int>("Vitorias");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TimesDosGrupos");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Torneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<DateTime>("DataDeInicioDoTorneio");

                    b.Property<int>("QuantidadeDeGrupos");

                    b.Property<int>("QuantidadeDeTimes");

                    b.HasKey("Id");

                    b.ToTable("Torneios");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Jogadores.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("NumeroDaCamisa")
                        .HasMaxLength(2);

                    b.Property<int>("Posicao")
                        .HasMaxLength(2);

                    b.Property<int?>("TimeId");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas.GolsDaPartida", b =>
                {
                    b.HasOne("Fiap.ProjetoFifa2018.Dominio.Entidades.Partidas.Partida", "Partida")
                        .WithMany("Gols")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Grupo", b =>
                {
                    b.HasOne("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Torneio", "Torneio")
                        .WithMany("Grupos")
                        .HasForeignKey("TorneioId");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.TimeDoGrupo", b =>
                {
                    b.HasOne("Fiap.ProjetoFifa2018.Dominio.Entidades.Torneios.Grupo", "Grupo")
                        .WithMany("Times")
                        .HasForeignKey("GrupoId");
                });

            modelBuilder.Entity("Fiap.ProjetoFifa2018.Dominio.Jogadores.Jogador", b =>
                {
                    b.HasOne("Fiap.ProjetoFifa2018.Dominio.Entidades.Times.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId");
                });
#pragma warning restore 612, 618
        }
    }
}
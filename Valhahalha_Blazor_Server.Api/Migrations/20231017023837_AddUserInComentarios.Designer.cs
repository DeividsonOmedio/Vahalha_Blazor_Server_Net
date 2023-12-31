﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Valhahalha_Blazor_Server.Api.Context;

#nullable disable

namespace Valhahalha_Blazor_Server.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231017023837_AddUserInComentarios")]
    partial class AddUserInComentarios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Valhahalha_Blazor_ServerSide.Model.Albun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Artista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Valhahalha_Blazor_ServerSide.Model.Comentari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Album")
                        .HasColumnType("int");

                    b.Property<int?>("AlbunsIdId")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbunsIdId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Valhahalha_Blazor_ServerSide.Model.Comentari", b =>
                {
                    b.HasOne("Valhahalha_Blazor_ServerSide.Model.Albun", "AlbunsId")
                        .WithMany()
                        .HasForeignKey("AlbunsIdId");

                    b.Navigation("AlbunsId");
                });
#pragma warning restore 612, 618
        }
    }
}

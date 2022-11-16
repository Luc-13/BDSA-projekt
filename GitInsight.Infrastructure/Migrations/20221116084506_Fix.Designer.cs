﻿// <auto-generated />
using System;
using GitInsight.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GitInsight.Infrastructure.Migrations
{
    [DbContext(typeof(GitInsightContext))]
    [Migration("20221116084506_Fix")]
    partial class Fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GitInsight.Infrastructure.Commit", b =>
                {
                    b.Property<int>("CommitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommitId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int?>("RepoId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CommitId");

                    b.HasIndex("RepoId");

                    b.HasIndex("UserId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("GitInsight.Infrastructure.Repo", b =>
                {
                    b.Property<int>("RepoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RepoId"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("RepoId");

                    b.ToTable("Repos");
                });

            modelBuilder.Entity("GitInsight.Infrastructure.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GitInsight.Infrastructure.Commit", b =>
                {
                    b.HasOne("GitInsight.Infrastructure.Repo", "Repo")
                        .WithMany()
                        .HasForeignKey("RepoId");

                    b.HasOne("GitInsight.Infrastructure.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Repo");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

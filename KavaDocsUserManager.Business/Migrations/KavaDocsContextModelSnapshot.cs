﻿// <auto-generated />
using KavaDocsUserManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace KavaDocsUserManager.Business.Migrations
{
    [DbContext(typeof(KavaDocsContext))]
    partial class KavaDocsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.OrganizationRepository", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("RepositoryId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("OrganizationRepositories");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.Repository", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IncludeInSearchResults");

                    b.Property<bool>("IsActive");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Settings");

                    b.Property<string>("TableOfContents");

                    b.Property<string>("Tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.RepositoryUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsOwner");

                    b.Property<Guid>("RepositoryId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRepositories");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserDisplayName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.OrganizationRepository", b =>
                {
                    b.HasOne("KavaDocsUserManager.Business.Models.Organization", "Organization")
                        .WithMany("Repositories")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KavaDocsUserManager.Business.Models.Repository", "Respository")
                        .WithMany()
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.Repository", b =>
                {
                    b.HasOne("KavaDocsUserManager.Business.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("KavaDocsUserManager.Business.Models.RepositoryUser", b =>
                {
                    b.HasOne("KavaDocsUserManager.Business.Models.Repository", "Respository")
                        .WithMany("Users")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KavaDocsUserManager.Business.Models.User", "User")
                        .WithMany("Repositories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

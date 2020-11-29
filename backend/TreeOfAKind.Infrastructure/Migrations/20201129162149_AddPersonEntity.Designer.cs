﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreeOfAKind.Infrastructure.Database;

namespace TreeOfAKind.Infrastructure.Migrations
{
    [DbContext(typeof(TreesContext))]
    [Migration("20201129162149_AddPersonEntity")]
    partial class AddPersonEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TreeOfAKind.Domain.Trees.Tree", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Trees", "trees");
                });

            modelBuilder.Entity("TreeOfAKind.Domain.UserProfiles.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserAuthId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthId")
                        .IsUnique();

                    b.ToTable("UserProfiles", "trees");
                });

            modelBuilder.Entity("TreeOfAKind.Infrastructure.Processing.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", "app");
                });

            modelBuilder.Entity("TreeOfAKind.Infrastructure.Processing.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", "app");
                });

            modelBuilder.Entity("TreeUserProfile", b =>
                {
                    b.Property<Guid>("_ownedTreesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("_treeOwnersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("_ownedTreesId", "_treeOwnersId");

                    b.HasIndex("_treeOwnersId");

                    b.ToTable("TreeUserProfile");
                });

            modelBuilder.Entity("TreeOfAKind.Domain.Trees.Tree", b =>
                {
                    b.OwnsMany("TreeOfAKind.Domain.Trees.People.Person", "_people", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("TreeId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("TreeId");

                            b1.ToTable("People", "trees");

                            b1.WithOwner("Tree")
                                .HasForeignKey("TreeId");

                            b1.Navigation("Tree");
                        });

                    b.Navigation("_people");
                });

            modelBuilder.Entity("TreeUserProfile", b =>
                {
                    b.HasOne("TreeOfAKind.Domain.Trees.Tree", null)
                        .WithMany()
                        .HasForeignKey("_ownedTreesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeOfAKind.Domain.UserProfiles.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("_treeOwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

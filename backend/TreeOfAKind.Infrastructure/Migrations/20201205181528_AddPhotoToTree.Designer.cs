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
    [Migration("20201205181528_AddPhotoToTree")]
    partial class AddPhotoToTree
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

                    b.Property<string>("Photo")
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

            modelBuilder.Entity("TreeOfAKind.Domain.Trees.Tree", b =>
                {
                    b.OwnsMany("TreeOfAKind.Domain.Trees.People.Person", "People", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Biography")
                                .IsRequired()
                                .HasMaxLength(10000)
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("BirthDate")
                                .HasColumnType("date");

                            b1.Property<DateTime?>("DeathDate")
                                .HasColumnType("date");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Gender")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<Guid>("TreeId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("TreeId");

                            b1.ToTable("People", "trees");

                            b1.WithOwner("Tree")
                                .HasForeignKey("TreeId");

                            b1.Navigation("Tree");
                        });

                    b.OwnsOne("TreeOfAKind.Domain.Trees.TreeRelations", "TreeRelations", b1 =>
                        {
                            b1.Property<Guid>("TreeId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("TreeId");

                            b1.ToTable("Trees");

                            b1.WithOwner()
                                .HasForeignKey("TreeId");

                            b1.OwnsMany("TreeOfAKind.Domain.Trees.Relation", "Relations", b2 =>
                                {
                                    b2.Property<Guid>("From")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("To")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("RelationType")
                                        .HasMaxLength(128)
                                        .HasColumnType("nvarchar(128)");

                                    b2.Property<Guid>("TreeId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("From", "To", "RelationType");

                                    b2.HasIndex("TreeId");

                                    b2.ToTable("TreeRelations", "trees");

                                    b2.WithOwner()
                                        .HasForeignKey("TreeId");
                                });

                            b1.Navigation("Relations");
                        });

                    b.OwnsMany("TreeOfAKind.Domain.Trees.TreeUserProfile", "TreeOwners", b1 =>
                        {
                            b1.Property<Guid>("TreeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("TreeId", "UserId");

                            b1.ToTable("TreeUserProfile", "trees");

                            b1.WithOwner()
                                .HasForeignKey("TreeId");
                        });

                    b.Navigation("People");

                    b.Navigation("TreeOwners");

                    b.Navigation("TreeRelations")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

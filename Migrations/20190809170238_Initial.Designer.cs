﻿// <auto-generated />
using System;
using EFOwnedEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFOwnedEntities.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190809170238_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFOwnedEntities.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<bool>("IsScary");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("EFOwnedEntities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MonsterId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("EFOwnedEntities.Monster", b =>
                {
                    b.OwnsMany("EFOwnedEntities.Limb", "Limbs", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Covering");

                            b1.Property<int>("Length");

                            b1.Property<int>("MonsterId");

                            b1.HasKey("Id");

                            b1.HasIndex("MonsterId");

                            b1.ToTable("Limb");

                            b1.HasOne("EFOwnedEntities.Monster")
                                .WithMany("Limbs")
                                .HasForeignKey("MonsterId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("EFOwnedEntities.Tail", "Tail", b1 =>
                        {
                            b1.Property<int>("MonsterId");

                            b1.Property<string>("Description");

                            b1.HasKey("MonsterId");

                            b1.ToTable("Tails");

                            b1.HasOne("EFOwnedEntities.Monster")
                                .WithOne("Tail")
                                .HasForeignKey("EFOwnedEntities.Tail", "MonsterId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("EFOwnedEntities.Owner", b =>
                {
                    b.HasOne("EFOwnedEntities.Monster")
                        .WithMany("Owners")
                        .HasForeignKey("MonsterId");
                });
#pragma warning restore 612, 618
        }
    }
}

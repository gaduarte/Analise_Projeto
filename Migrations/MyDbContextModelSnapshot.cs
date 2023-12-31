﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace biblioteca_trabalho.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("biblioteca_trabalho.Models.Alert", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("longtext");

                    b.Property<int?>("Fine")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LibrarianId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LibrarianId")
                        .IsUnique();

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Books", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("longtext");

                    b.Property<string>("BookName")
                        .HasColumnType("longtext");

                    b.Property<int?>("CatalogId")
                        .HasColumnType("int");

                    b.Property<int?>("Librarian1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Librarian2Id")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("NoofBooks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.HasIndex("Librarian1Id");

                    b.HasIndex("Librarian2Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Catalog", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("longtext");

                    b.Property<int?>("NoofCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Librarian", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adrdress")
                        .HasColumnType("longtext");

                    b.Property<int?>("AlertId")
                        .HasColumnType("int");

                    b.Property<int?>("Mobileno")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Member", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Maddress")
                        .HasColumnType("longtext");

                    b.Property<string>("Mname")
                        .HasColumnType("longtext");

                    b.Property<int?>("Mno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibrarianMember", b =>
                {
                    b.Property<int>("LibrariansId")
                        .HasColumnType("int");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.HasKey("LibrariansId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("LibrarianMember");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.FacultyMember", b =>
                {
                    b.HasBaseType("biblioteca_trabalho.Models.Member");

                    b.Property<string>("FacultyColl")
                        .HasColumnType("longtext");

                    b.Property<string>("Fname")
                        .HasColumnType("longtext");

                    b.ToTable("FacultyMember", (string)null);
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.GeneralBook", b =>
                {
                    b.HasBaseType("biblioteca_trabalho.Models.Books");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Edicao")
                        .HasColumnType("longtext");

                    b.ToTable("GeneralBooks", (string)null);
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.RefrenceBook", b =>
                {
                    b.HasBaseType("biblioteca_trabalho.Models.Books");

                    b.Property<string>("Avaliacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("Citacoes")
                        .HasColumnType("longtext");

                    b.Property<int?>("Preco")
                        .HasColumnType("int");

                    b.ToTable("RefrenceBooks", (string)null);
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Student", b =>
                {
                    b.HasBaseType("biblioteca_trabalho.Models.Member");

                    b.Property<string>("Sname")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentColl")
                        .HasColumnType("longtext");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Alert", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Librarian", "Librarian")
                        .WithOne("Alert")
                        .HasForeignKey("biblioteca_trabalho.Models.Alert", "LibrarianId");

                    b.Navigation("Librarian");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Books", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Catalog", "Catalog")
                        .WithMany("Book")
                        .HasForeignKey("CatalogId");

                    b.HasOne("biblioteca_trabalho.Models.Librarian", "Librarian1")
                        .WithMany()
                        .HasForeignKey("Librarian1Id");

                    b.HasOne("biblioteca_trabalho.Models.Librarian", "Librarian2")
                        .WithMany()
                        .HasForeignKey("Librarian2Id");

                    b.HasOne("biblioteca_trabalho.Models.Member", "Member")
                        .WithMany("Books")
                        .HasForeignKey("MemberId");

                    b.Navigation("Catalog");

                    b.Navigation("Librarian1");

                    b.Navigation("Librarian2");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibrarianMember", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Librarian", null)
                        .WithMany()
                        .HasForeignKey("LibrariansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("biblioteca_trabalho.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.FacultyMember", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("biblioteca_trabalho.Models.FacultyMember", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.GeneralBook", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Books", null)
                        .WithOne()
                        .HasForeignKey("biblioteca_trabalho.Models.GeneralBook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.RefrenceBook", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Books", null)
                        .WithOne()
                        .HasForeignKey("biblioteca_trabalho.Models.RefrenceBook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Student", b =>
                {
                    b.HasOne("biblioteca_trabalho.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("biblioteca_trabalho.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Catalog", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Librarian", b =>
                {
                    b.Navigation("Alert");
                });

            modelBuilder.Entity("biblioteca_trabalho.Models.Member", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

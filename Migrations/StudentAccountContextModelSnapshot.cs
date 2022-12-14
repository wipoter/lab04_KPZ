// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labb04_KPZ.Models;

#nullable disable

namespace labb04KPZ.Migrations
{
    [DbContext(typeof(StudentAccountContext))]
    partial class StudentAccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("labb04_KPZ.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Loggin")
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("labb04_KPZ.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Describtion")
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nchar(40)")
                        .IsFixedLength();

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("Student_Id");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Achievement", (string)null);
                });

            modelBuilder.Entity("labb04_KPZ.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_Id");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Institute")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.Property<int?>("Num")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "IX_Student")
                        .IsUnique()
                        .HasFilter("[Account_Id] IS NOT NULL");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("labb04_KPZ.Models.Achievement", b =>
                {
                    b.HasOne("labb04_KPZ.Models.Student", "Student")
                        .WithMany("Achievements")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_Achievement_Student");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("labb04_KPZ.Models.Student", b =>
                {
                    b.HasOne("labb04_KPZ.Models.Account", "Account")
                        .WithOne("Student")
                        .HasForeignKey("labb04_KPZ.Models.Student", "AccountId")
                        .HasConstraintName("FK_Student_Account1");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("labb04_KPZ.Models.Account", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("labb04_KPZ.Models.Student", b =>
                {
                    b.Navigation("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}

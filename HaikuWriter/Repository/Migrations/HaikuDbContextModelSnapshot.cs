﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(HaikuDbContext))]
    partial class HaikuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Haiku", b =>
                {
                    b.Property<int>("HaikuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<int?>("HaikuLine1HaikuLineId")
                        .HasColumnType("int");

                    b.Property<int?>("HaikuLine2HaikuLineId")
                        .HasColumnType("int");

                    b.Property<int?>("HaikuLine3HaikuLineId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HaikuId");

                    b.HasIndex("HaikuLine1HaikuLineId");

                    b.HasIndex("HaikuLine2HaikuLineId");

                    b.HasIndex("HaikuLine3HaikuLineId");

                    b.HasIndex("Username");

                    b.ToTable("Haikus");
                });

            modelBuilder.Entity("Models.HaikuLine", b =>
                {
                    b.Property<int>("HaikuLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Syllable")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HaikuLineId");

                    b.HasIndex("Username");

                    b.ToTable("HaikuLines");
                });

            modelBuilder.Entity("Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("messageBody")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("Username");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Models.Thread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ThreadId");

                    b.HasIndex("Username");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AdminStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MemberSince")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TwitterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserFav", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HaikuId")
                        .HasColumnType("int");

                    b.HasKey("Username", "HaikuId");

                    b.HasIndex("HaikuId");

                    b.ToTable("UserFavs");
                });

            modelBuilder.Entity("Models.Haiku", b =>
                {
                    b.HasOne("Models.HaikuLine", "HaikuLine1")
                        .WithMany()
                        .HasForeignKey("HaikuLine1HaikuLineId");

                    b.HasOne("Models.HaikuLine", "HaikuLine2")
                        .WithMany()
                        .HasForeignKey("HaikuLine2HaikuLineId");

                    b.HasOne("Models.HaikuLine", "HaikuLine3")
                        .WithMany()
                        .HasForeignKey("HaikuLine3HaikuLineId");

                    b.HasOne("Models.User", "User")
                        .WithMany("Haikus")
                        .HasForeignKey("Username");

                    b.Navigation("HaikuLine1");

                    b.Navigation("HaikuLine2");

                    b.Navigation("HaikuLine3");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.HaikuLine", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("HaikuLines")
                        .HasForeignKey("Username");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Message", b =>
                {
                    b.HasOne("Models.Thread", "Thread")
                        .WithMany("Messages")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("Username");

                    b.Navigation("Thread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Thread", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("Threads")
                        .HasForeignKey("Username");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.UserFav", b =>
                {
                    b.HasOne("Models.Haiku", "Haiku")
                        .WithMany("UserFavs")
                        .HasForeignKey("HaikuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("UserFavs")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Haiku");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Haiku", b =>
                {
                    b.Navigation("UserFavs");
                });

            modelBuilder.Entity("Models.Thread", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("HaikuLines");

                    b.Navigation("Haikus");

                    b.Navigation("Messages");

                    b.Navigation("Threads");

                    b.Navigation("UserFavs");
                });
#pragma warning restore 612, 618
        }
    }
}

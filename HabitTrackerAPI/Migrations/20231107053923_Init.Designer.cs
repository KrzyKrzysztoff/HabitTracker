﻿// <auto-generated />
using System;
using HabitTrackerAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitTrackerAPI.Migrations
{
    [DbContext(typeof(HabitTrackerDbContext))]
    [Migration("20231107053923_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HabitTrackerAPI.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActiveDaysStrike")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImportantId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ImportantId");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Important", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Important");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.ScheduleHabit", b =>
                {
                    b.Property<int>("HabitId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 7, 6, 39, 23, 142, DateTimeKind.Local).AddTicks(5560));

                    b.HasKey("HabitId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleHabits");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DestinationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImportantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ImportantId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.TargetUser", b =>
                {
                    b.Property<Guid>("TargetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CrateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 7, 6, 39, 23, 142, DateTimeKind.Local).AddTicks(2969));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("TargetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TargetUsers");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 7, 6, 39, 23, 142, DateTimeKind.Local).AddTicks(157));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Account", b =>
                {
                    b.HasBaseType("HabitTrackerAPI.Entities.User");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Account");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Habit", b =>
                {
                    b.HasOne("HabitTrackerAPI.Entities.Important", "Important")
                        .WithMany("Habits")
                        .HasForeignKey("ImportantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Important");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.ScheduleHabit", b =>
                {
                    b.HasOne("HabitTrackerAPI.Entities.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitTrackerAPI.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Target", b =>
                {
                    b.HasOne("HabitTrackerAPI.Entities.Important", "Important")
                        .WithMany("Targets")
                        .HasForeignKey("ImportantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Important");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.TargetUser", b =>
                {
                    b.HasOne("HabitTrackerAPI.Entities.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitTrackerAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Target");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.User", b =>
                {
                    b.HasOne("HabitTrackerAPI.Entities.Address", "Address")
                        .WithOne("User")
                        .HasForeignKey("HabitTrackerAPI.Entities.User", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HabitTrackerAPI.Entities.Schedule", "Schedule")
                        .WithOne("User")
                        .HasForeignKey("HabitTrackerAPI.Entities.User", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Address", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Important", b =>
                {
                    b.Navigation("Habits");

                    b.Navigation("Targets");
                });

            modelBuilder.Entity("HabitTrackerAPI.Entities.Schedule", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoard.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            Name = "Questions"
                        },
                        new
                        {
                            GroupId = 2,
                            Name = "Homework"
                        },
                        new
                        {
                            GroupId = 3,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contents")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.HasIndex("GroupId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Author = "Dwight",
                            Contents = "Which bear is best?",
                            Date = "1/1/2021",
                            GroupId = 1,
                            Title = "Bears Question"
                        },
                        new
                        {
                            MessageId = 2,
                            Author = "Jessica",
                            Contents = "This homework sucks",
                            Date = "2/3/2021",
                            GroupId = 2,
                            Title = "Lesson 9 Homework"
                        },
                        new
                        {
                            MessageId = 3,
                            Author = "Tim",
                            Contents = "You can add to a list but not to an array",
                            Date = "3/4/2021",
                            GroupId = 3,
                            Title = "C# - Lists and Arrays"
                        },
                        new
                        {
                            MessageId = 4,
                            Author = "Jim",
                            Contents = "I don't understand Lesson 16",
                            Date = "4/4/2021",
                            GroupId = 2,
                            Title = "Homework Help"
                        },
                        new
                        {
                            MessageId = 5,
                            Author = "Stephanie",
                            Contents = "Do you like potatoes?",
                            Date = "5/4/2021",
                            GroupId = 1,
                            Title = "Potato Question"
                        },
                        new
                        {
                            MessageId = 6,
                            Author = "Jen",
                            Contents = "which lion is strongest?",
                            Date = "6/4/2021",
                            GroupId = 1,
                            Title = "Lions Question"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.HasOne("MessageBoard.Models.Group", "Group")
                        .WithMany("Messages")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MessageBoard.Models.Group", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}

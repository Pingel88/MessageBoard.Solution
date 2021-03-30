using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      DateTime Date1 = DateTime.Parse("01/02/2021");
      DateTime Date2 = DateTime.Parse("03/21/2021");
      DateTime Date3 = DateTime.Parse("02/12/2021");
      builder.Entity<Message>()
      .HasData(
        new Message { MessageId = 1, Title = "Bears Question", Author = "Dwight", Date = Date1, Contents = "Which bear is best?", GroupId = 1},
        new Message { MessageId = 2, Title = "Lesson 9 Homework", Author = "Jessica", Date = Date2, Contents = "This homework sucks", GroupId = 2},
        new Message { MessageId = 3, Title = "C# - Lists and Arrays", Author = "Tim", Date = Date1, Contents = "You can add to a list but not to an array", GroupId = 3},
        new Message { MessageId = 4, Title = "Homework Help", Author = "Jim", Date = Date2, Contents = "I don't understand Lesson 16", GroupId = 2},
        new Message { MessageId = 5, Title = "Potato Question", Author = "Stephanie", Date = Date3, Contents = "Do you like potatoes?", GroupId = 1},
        new Message { MessageId = 6, Title = "Lions Question", Author = "Jen", Date = Date1, Contents = "which lion is strongest?", GroupId = 1}
      );

      builder.Entity<Group>()
      .HasData(
        new Group { GroupId = 1, Name = "Questions"},
        new Group { GroupId = 2, Name = "Homework"},
        new Group { GroupId = 3, Name = "C#"}
      );

    }
    public DbSet<Message> Messages { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
  }
}
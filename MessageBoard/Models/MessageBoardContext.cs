using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
      .HasData(
        new Message { MessageId = 1, Title = "Yo", Author = "Bob", Date = "1/1/2021", Contents = "What's up"},
        new Message { MessageId = 2, Title = "Whatever", Author = "Jessica", Date = "2/3/2021", Contents = "hello goodbye"},
        new Message { MessageId = 3, Title = "Bye", Author = "Tim", Date = "3/4/2021", Contents = "sdfdfsdfds"}
      );

    }
    public DbSet<Message> Messages { get; set; }
  }
}
namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Date { get; set; }
    public string Contents { get; set; }
  }
}

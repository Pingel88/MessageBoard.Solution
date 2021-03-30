using System.Collections.Generic;

namespace MessageBoard.Models
{
  public class Group
  {
    public Group()
    {
      this.Messages = new HashSet<Message>();
    }
    
    public int GroupId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
  }
}
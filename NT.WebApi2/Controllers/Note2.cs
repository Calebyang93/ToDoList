
namespace NT.WebApi2.Controllers
{
  public class Note2
  {
    public Guid ID { get; set; }
    public string Username { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string Title { get; set; }
    public string NoteContent { get; set; }
  }
}
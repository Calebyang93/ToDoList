using Microsoft.AspNetCore.Mvc;

namespace NT.WebApi2.Controllers
{
  public interface IToDoListService
  {
    public bool DeleteNote(Guid noteId);
    public IActionResult Save([FromBody] Note2 note);

  }
}
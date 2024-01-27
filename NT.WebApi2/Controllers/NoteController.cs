using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Fabric.Query;
using System.Net;

namespace NT.WebApi2.Controllers
{
  public class NoteController : ControllerBase
  {
    private readonly IToDoListService _toDoListService;

    [HttpGet]
    [Route("api/Note/GetAll")]
    public IEnumerable<Note2> GetAll()
    {
      return Enumerable.Range(0, 4).Select(index => new Note2
      {
        ID = Guid.NewGuid(),
        Username = "User" + ((char)((int)'a' +
                      Random.Shared.Next(0, 25))).ToString().ToUpper(),
        CreatedOn = DateTime.Now.AddDays(index - 1),
        UpdatedOn = DateTime.Now.AddDays(index),
        Title = ((char)((int)'a' + Random.Shared.Next(0, 25))).ToString().ToUpper(),
        NoteContent = ((char)((int)'a' + Random.Shared.Next(0, 25))).ToString(),
      })
       .ToArray();
    }

    [HttpGet]
    [Route("api/Note/GetByID/{id}")]
    public Note2 GetById(Guid Id)
    {
      return new Note2
      {
        ID = Id,
        Username = "User" + ((char)((int)'a' + Random.Shared.Next(0, 25))).ToString().ToUpper(),
        CreatedOn = DateTime.Now.AddDays(-1),
        UpdatedOn = DateTime.Now,
        Title = ((char)((int)'a' + Random.Shared.Next(0, 25))).ToString().ToUpper(),
        NoteContent = ((char)((int)'a' + Random.Shared.Next(0, 25))).ToString(),
      };
    }


    [HttpGet]
    [Route("api/Note/SaveNote")]
    public IActionResult Save([FromBody] Note2 note)
    {
      _toDoListService.Save(note);
      try
      {
        return Ok($"Note saved successfully on  {DateTime.Now}");
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occured for saving the note");
      }
    }

    [HttpPost]
    [Route("api/Note/deleteNote")]
    public IActionResult DeleteNoteById([FromBody] Guid noteId)
    {
      _toDoListService.DeleteNote(noteId);
      try
      {
        bool isDeleted = _toDoListService.DeleteNote(noteId);
        if (isDeleted)
        {
          return Ok($"Note {noteId} deleted successfully");
        }
        else
        {
          return NotFound($"Note {noteId} not found or could not be deleted.");
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"An error occured while delete Note {noteId}");
      }
    }

    //[HttpDelete]
    //[Route("api/deleteStatusCode")]

    //public static async Task<HttpStatusCode> DeleteNoteStatusCode([FromBody] Guid noteId, object client)
    //{
    //  HttpResponseMessage response = await client.DeleteAsync(
    //    $"api/deletestatuscode/{noteId}");
    //  return response.StatusCode;
    //}


    [HttpGet]
    [Route("api/Note/getNotes")]

    public List<Note2> GetNotes(string baseAddress)
    {
      using (HttpClient httpClient = new HttpClient())
      {
        string path = "/Note/api/NoteController/GetAllNotes";

        httpClient.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = httpClient.GetAsync(path).Result;
        if (response.IsSuccessStatusCode)
        {
          Console.WriteLine("Success");
          string message = response.Content.ReadAsStringAsync().Result;
          Console.WriteLine($"Response: {message}");
          List<Note2> lst = JsonConvert.DeserializeObject<List<Note2>>(message);
          return lst;
        }
        else
        {
          Console.WriteLine($"Problem! [{response.ReasonPhrase}]");
          return new List<Note2>();
        }
      }
    }
  }
}

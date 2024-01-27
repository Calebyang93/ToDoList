using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace NT.WebApi2.Controllers
{
  [ApiController]
  [Route("api/notes2")]
  public class MockNotesController : Controller
  {
    MockNotes[] mocknotes = new MockNotes[]
    {
      new MockNotes { Id = 1, Username = "Romania Joe", Title = "Cooking for Work", CreatedOn = "2023/09/04", UpdatedOn = "2023/10/04", Color  = "Navy Blue", FontSize = "18"  },
       new MockNotes { Id = 2, Username = "Bosnia Sally", Title = "Laundry", CreatedOn = "2022/11/04", UpdatedOn = "2022/11/11", Color  = "Orange", FontSize = "18"  },
        new MockNotes { Id = 3, Username = "Bulgaria Thomas", Title = "Sweep, Mop Vacuum Floor", CreatedOn = "2022/03/04", UpdatedOn = "2022/04/04", Color  = "Dark Green", FontSize = "18"  },
         new MockNotes { Id = 4, Username = "Hungary Vladmir", Title = "Wash Toilet", CreatedOn = "2021/12/24", UpdatedOn = "2021/01/24", Color  = "Maroon", FontSize = "18"  },
          new MockNotes { Id = 5, Username = "Serbia Joe", Title = "Declutter Room", CreatedOn = "2021/04/07", UpdatedOn = "2021/05/10", Color  = "Purple", FontSize = "18"  },
    };
    public IActionResult Index()
    {
      return View();
    }
  }

  public class MockNotes
  {
    public int Id { get; internal set; }
    public string Username { get; internal set; }
    public string Title { get; internal set; }
    public string CreatedOn { get; internal set; }
    public string UpdatedOn { get; internal set; }
    public string Color { get; internal set; }
    public string FontSize { get; internal set; }
  }
}


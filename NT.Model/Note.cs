using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Model
{
 // [Table("Notes")] // Required (at least for Dapper.Contrib) when the table name is not the same as the entity name
  public class Note
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn {get; set; }
        public string Colour { get; set; }
        public int FontSize { get; set; }

        public Note() {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
        public List<Note> AsLongString(List<Note> n)
        {
            if (string.IsNullOrEmpty(n.Count().ToString()))
            {
                Console.WriteLine("Content for Note is null or empty, enter content for note in the db");
            }
             else
            {
                Console.WriteLine("N is not able to be expresssed in long string format");
            }
            return n;
        }

        public List<Note> AsShortString(List<Note> n)
        {
            if (string.IsNullOrEmpty(n.Count().ToString()))
            {
                Console.WriteLine("Content for Note is null or empty, enter content for note in the db");
            }
            else
            {
                 Console.WriteLine("N is not able to be expresssed in short string format");
            }
            return n;
        }
    }
}

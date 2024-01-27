using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Model
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } = "";
        public DateTime CreatedOn { get; set; }

        public Note() // constructor
        {
            Id = new Guid();
            Title = "title unset";
            Content = "content unset";
            CreatedOn = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Title}: {Content}, Created on: {CreatedOn}";
        }
        public string AsLongString()
        {
            return $"{Title}: {Content}, Created on: {CreatedOn}";
        }
        public string AsShortString()
        {
            return $"{Title}|{Content}";
        }
    }
}

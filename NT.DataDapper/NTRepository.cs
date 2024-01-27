using NT.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NT.Model;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace NT.DataDapper
{
  public class NTRepository : INTRepository
  {
    private string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";
    public void Delete(Note n)
    {
      using (var conn = new SqlConnection(connStr))
        conn.Delete<Note>(n);
    }

    public void DeleteById(Guid id)
    {
      Note n = GetById(id);
      Delete(n);
    }

    public Note GetById(Guid id)
    {
      return new Note { Id = id };
    }


    public List<Note> GetAll()
    {
      List<Note> notes = new List<Note>();
      using (var conn = new SqlConnection(connStr))
        notes = conn.GetAll<Note>().ToList();
      return notes;
    }

    public void Insert(Note n)
    {
      using (var conn = new SqlConnection(connStr))
        conn.Insert<Note>(n);
    }

    public void Update(Note n)
    {
      using (var conn = new SqlConnection(connStr))
        conn.Update<Note>(n);
    }

    public void Save(Note n)
    {
      using (var conn = new SqlConnection(connStr))
        conn.Insert<Note>(n);
    }
  }
}

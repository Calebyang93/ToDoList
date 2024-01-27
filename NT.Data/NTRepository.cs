using NT.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.SqlServer.Server;
using System.Linq.Expressions;
using log4net;
using NT.DataInterface;
//using NT.DataInterface;

namespace NT.Data
{
  public class NTRepository : INTRepository
  {
    private ILog log;
    private string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";

    public NTRepository()
    {
      log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
    public List<Note> GetAll()
    {
      DataTable dt = new DataTable();
      List<Note> lst = new List<Note>();
      using (SqlConnection conn = new SqlConnection(connStr))
      {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from Notes", conn);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = cmd;
        adapter.Fill(dt);
        conn.Close();

        foreach (DataRow dr in dt.Rows)
        {
          Note n = new Note();
          n.Id = new Guid(dr[0].ToString());
          n.Username = dr[1].ToString();
          n.Title = dr[2].ToString();
          n.NoteText = dr[3].ToString();
          n.CreatedOn = Convert.ToDateTime(dr[4]);
          n.UpdatedOn = Convert.ToDateTime(dr[5]);
          n.Colour = dr[6].ToString();
          lst.Add(n);
        }
      }
      return lst;
    }

    public void DeleteById(Guid id)
    {
      DataTable dt = new DataTable();
      List<Note> lst = new List<Note>();
      using (SqlConnection conn = new SqlConnection(connStr))
      {
        conn.Open();
        SqlCommand cmd = new SqlCommand($"delete from Notes WHERE id = '{id}'", conn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
      }
    }

    public void Delete(Note n)
    {
      DeleteById(n.Id);
    }

    public void Update(Note n)
    {
      string sql = $@"UPDATE [dbo].[Notes]
   SET 
      [Username] = '{n.Username}'
      ,[Title] = '{n.Title}'
      ,[NoteText] = '{n.NoteText}'      
      ,[UpdatedOn] = '{DateTime.Now.ToString("yyyy-MM-dd")}'
      ,[Colour] = '{n.Colour}'
 WHERE  Id = '{n.Id}'";

      using (SqlConnection conn = new SqlConnection(connStr))
      {
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
      }
    }

    public void Insert(Note n)
    {
      string sql = $@"INSERT INTO [dbo].[Notes]
           ([Username]
           ,[Title]
           ,[NoteText]
           ,[CreatedOn]
           ,[UpdatedOn]
            ,[Colour])
     VALUES
           ('{n.Username}','{n.Title}','{n.NoteText}','{n.CreatedOn.ToString("yyyy-MM-dd")}','{n.UpdatedOn.ToString("yyyy-MM-dd")}', '{n.Colour.ToString()}')";

      try
      {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
          conn.Open();
          SqlCommand cmd = new SqlCommand(sql, conn);
          cmd.CommandType = CommandType.Text;
          cmd.ExecuteNonQuery();
        }
      }
      catch (Exception ex)
      {
        log.Error("Error in Insert: " + ex.Message + "" + sql);
      }
    }
  }
}

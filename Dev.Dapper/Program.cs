using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Dev.Dapper
{
  [Table("TestContacts")] // Required (at least for Dapper.Contrib) when the table name is not the same as the entity name
  public class Contact
  {
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Town { get; set; }
    public string County { get; set; }
    public string Company { get; set; }
    public string PostCode { get; set; }
    public string Tel1 { get; set; }
    public string Tel2 { get; set; }
    public string EMail { get; set; }
    public string URL { get; set; }
  }
  internal class Program
  {
    static void Main(string[] args)
    {
      // Useful links:
      // https://peterdaugaardrasmussen.com/2022/06/13/charp-dapper-how-to-make-select-insert-update-and-delete-statements/#delete
      // https://peterdaugaardrasmussen.com/2018/02/26/dapper-set-name-of-table-to-something-other-than-table/
      // https://www.learndapper.com/


      // NuGet\Install-Package Dapper -Version 2.0.143
      // Address data found here: https://www.briandunning.com/sample-data/
      // - 500 records, now in JAS.TestContacts, with tweaked column names, added ID column

      // DapperMin();

      DapperContrib();

      Console.WriteLine("Press ENTER to end...");
      Console.ReadLine();
    }

    private static void DapperContrib()
    {
      // Install Dapper.Contrib
      string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";

      // C
      Contact c = new Contact() { FirstName = "B", LastName = "Smith", Address = "1 Main Street", Town = "Anytown" };
      using (var conn = new SqlConnection(connStr))
        conn.Insert<Contact>(c);

      // R
      List<Contact> contacts = new List<Contact>();
      using (var conn = new SqlConnection(connStr))
        contacts = conn.GetAll<Contact>().ToList();

      // U
      c.FirstName += "Y";
      using (var conn = new SqlConnection(connStr))
        conn.Update<Contact>(c);

      // D
      using (var conn = new SqlConnection(connStr))
        conn.Delete<Contact>(c);
    }

    private static void DapperMin()
    {
      string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";

      // C: Add new
      Contact c = new Contact()
      {
        FirstName = "A",
        LastName = "Smith",
        Address = "1 Main Street",
        Town = "Anytown",
      };

      using (var conn = new SqlConnection(connStr))
      {
        string sql = @"INSERT INTO TestContacts 
                               ([FirstName], [LastName], [Company], [Address], [Town], [County], [PostCode], [Tel1], [Tel2], [EMail], [URL]) 
                               VALUES (@FirstName, @LastName, @Company, @Address, @Town, @County, @Postcode, @Tel1, @Tel2, @EMail, @URL)";

        var result = conn.Execute(sql, c);
      }

      // R: Get all:
      List<Contact> contacts = new List<Contact>();
      using (var conn = new SqlConnection(connStr))
      {
        string sql = "select * from TestContacts";
        contacts = conn.Query<Contact>(sql).ToList();
      }

      // U: Update - by ID
      Contact u = contacts[0];
      u.FirstName += "X";

      using (var conn = new SqlConnection(connStr))
      {
        string sql = @"UPDATE TestContacts 
                          SET [FirstName] = @FirstName, [LastName] = @LastName, [Company] = @Company, [Address] = @Address, [Town] = @Town, 
                              [County] = @County, [PostCode] = @PostCode, [Tel1] = @Tel1, [Tel2] = @Tel2, [EMail] = @EMail, [URL] = @URL 
                          WHERE ID = @ID";
        var result = conn.Execute(sql, u);
      }

      // D: Delete - by ID
      Contact d = contacts.Where(x => x.FirstName == "A").FirstOrDefault();
      if (d != null)
      {
        using (var conn = new SqlConnection(connStr))
        {
          string sql = @"DELETE FROM TestContacts 
                            WHERE ID = @ID";
          var result = conn.Execute(sql, d);
        }
      }
    }
  }
}

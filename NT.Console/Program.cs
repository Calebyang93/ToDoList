using log4net;
using NT.DataDapper;
using NT.DataInterface;
using NT.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteTaking11Dec2023
{

    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("This is a notetaking application");

            ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("hello");

            //Note2 n = GetNoteFromUser();
            //List<Note2> n2 = GetNotesFromDatabase();

            //List<Note2> myNotes = new NTRepository().GetAll();

            NTRepository repository = new NTRepository();

            // DELETE
            //repository.DeleteById(new Guid("2bd95ec1-a5c5-43b3-b9f9-995f6ac69fde"));

            // READ
            var lst = repository.GetAll();

            // UPDATE
            //Note2 n = lst.Where(x => x.Title.StartsWith("x")).FirstOrDefault();
            //n.Title = "yyy";
            //n.UpdatedOn = DateTime.Now;
            //n.Colour = "purple";
            //repository.Update(n);

            // INSERT
            Note n = new Note();
            n.Username = System.Environment.UserName;
            n.Title = "xxx123s";
            n.NoteText = "xxpristina is not serbia";
            n.Colour = "NavyBlue";
            repository.Insert(n);

            Console.WriteLine("Press ENTER to end");
            Console.ReadLine();

        }

        public List<Note> AsLongString(List<Note> n)
        {
            if (string.IsNullOrEmpty(n.Count().ToString()))
            {
                Console.WriteLine("Note does not contain the right amount of entries. Please check the db");
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
                Console.WriteLine("Note does not contain the right amount of entries. Please check the db");
            }
            else
            {
                Console.WriteLine("N is not able to be expresssed in short string format");
            }
            return n;
        }

        public static List<Note> GetNotesFromDatabase()
        {
            // ado.net code!
            //string connStr = @"Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS; Connection Timeout=1800";
            string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";
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
                    lst.Add(n);
                }
            }
            return lst;
        }
        public static List<Note> GetNotesFromDatabase1()
        {

            // ado.net code!
            //string connStr = @"Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS; Connection Timeout=1800";
            string connStr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NoteDBDec2023;Data Source=DESKTOP-2AS0J7C\SQLEXPRESS";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Notes", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                conn.Close();
            }
            Console.WriteLine("Rows in NoteDBDec2023: " + dt.Rows.Count.ToString());
            return new List<Note>();
        }
        private static Note GetNoteFromUser()
        {
            var n = new Note();

            Console.WriteLine("Enter the title of a note, and then press enter.");
            n.Title = Console.ReadLine();
            Console.WriteLine("Enter the content of a note, and then press enter.");
            n.NoteText = Console.ReadLine();
            return n;
        }
    }
}

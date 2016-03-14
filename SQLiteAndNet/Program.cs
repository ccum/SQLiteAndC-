using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteAndNet
{
    class Program
    {
        static void Main(string[] args)
        {
            String connString = "Data Source=D:\\testSQLite\\testDB.sqlite;Version=3;";
            //sqlite_conn = new SQLiteConnection("Data Source=C:\SQLITEDATABASES\SQLITEDB1.sqlite;Version=3;");
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * ");
                query.Append("FROM MyTable");
                //query.Append("ORDER BY name");
                using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
                {
                    conn.Open();
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetValue(0) + " " + dr.GetValue(1));
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

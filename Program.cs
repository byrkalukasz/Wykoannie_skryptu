using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Wykonanie_skryptu
{
    class Program
    {
        static void Main(string[] args)
        {
            //zczytywanie wartości do średnika
            string Komenda;
            string tekst;
            int offset = 0;
            string ConnectionString = @"Data Source=DESKTOP-AU4UUB7\SQLEXPRESS; Initial Catalog = Prison; Integrated Security = True;";
            StreamReader reader = new StreamReader("C:/Users/redik/Desktop/new 1.txt");
            SqlConnection connection = new SqlConnection(ConnectionString);
            Console.WriteLine("Połączenie otwarte");
            while ((tekst = reader.ReadLine()) != null)
            {
                offset = tekst.IndexOf(";");
                Komenda = tekst.Substring(offset - offset);
                Console.WriteLine(Komenda);
                SqlCommand sqlCommand = new SqlCommand(Komenda, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
            Console.WriteLine("Połaczenie zamknięte");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
// Используем пространство имен MySql.Date
using MySql.Data.MySqlClient;

namespace MySQLConsole
{
    class Row
    {
        string Name { get; set; }
        string District { get; set; }
        string Population { get; set; }
        public Row(string name, string district, string population)
        {
            this.Name = name;
            this.District = district;
            this.Population = population;
        }
        public string Print()
        {
            return ($"Столица {this.Name} страны {this.District},в которой проживает {this.Population}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost"; // Имя локального компьютера
            string database = "world"; // Имя базы данных
            string user = "root"; // Имя пользователя
            string password = "pass"; // Пароль пользователя

            string Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;

            // Создаем соединение с базой данных
            MySqlConnection mysql_connection = new MySqlConnection(Connect);

            // Создание SQL команды
            MySqlCommand mysql_query = mysql_connection.CreateCommand();
            mysql_query.CommandText = "SELECT * FROM world.city where Population > 500000;";

            try
            {
                mysql_connection.Open();
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                List<Row> Rwos = new List<Row>();
                while (mysql_result.Read())
                {
                    Rwos.Add(new Row(mysql_result.GetString(1), mysql_result.GetString(3), mysql_result.GetString(4)));
                }

                mysql_connection.Close();
                foreach (Row r in Rwos)
                    Console.WriteLine(r.Print());
            }
            catch
            {
                Console.WriteLine("Ошибка MySQL");
            }

        }
    }
}
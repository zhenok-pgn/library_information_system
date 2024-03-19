using Library.Infrastracture;
using Library.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class Reader : ValueType<Reader>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("ФИО")]
        public string Name { set; get; }
        [Label("Паспорт")]
        public string Passport { set; get; }
        [Label("Телефон")]
        public string Phone { set; get; }
        [Label("Адрес")]
        public string Adress { set; get; }

        public override string ToString()
        {
            return $"ID: {Id}; ФИО: {Name}";
        }
    }

    public class ReaderRepository
    {
        public static List<Reader> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var records = new List<Reader>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from reader", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Reader()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"],
                        Passport = (string)row["passport"],
                        Phone = (string)row["phone"],
                        Adress = (string)row["adress"]
                    };
                    records.Add(element);
                }
            }
            return records;
        }

        public static List<Reader> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var records = new List<Reader>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from reader where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Reader()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"],
                        Passport = (string)row["passport"],
                        Phone = (string)row["phone"],
                        Adress = (string)row["adress"]
                    };
                    records.Add(element);
                }
            }
            return records;
        }

        public static int Delete(Reader obj)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from reader where id = {obj.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(Reader reader)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into reader " +
                    $"(name, passport, phone, adress) " +
                    $"values(N'{reader.Name}', N'{reader.Passport}', N'{reader.Phone}', N'{reader.Adress}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(Reader reader)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update reader " +
                    $"set name = N'{reader.Name}', passport = N'{reader.Passport}', phone = N'{reader.Phone}', adress = N'{reader.Adress}'" +
                    $"where id = {reader.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

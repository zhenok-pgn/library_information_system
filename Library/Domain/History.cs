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
    public class History : ValueType<History>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("Книга")]
        public Books Book { set; get; }
        [Label("Читатель")]
        public Reader Reader { set; get; }
        [Label("Взята по")]
        public DateTime DateTo { set; get; }
        [Label("Взята с")]
        public DateTime DateFrom { set; get; }
    }

    public class HistoryRepository
    {
        public static List<History> SelectByBookId(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var records = new List<History>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from history where booksId = {id} order by dateTo desc", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new History()
                    {
                        Id = (int)row["id"],
                        Book = BooksRepository.SelectById((int)row["booksId"]),
                        Reader = ReaderRepository.SelectById((int)row["readerId"])[0],
                        DateFrom = Convert.ToDateTime(row["dateFrom"].ToString()),
                        DateTo = Convert.ToDateTime(row["dateTo"].ToString())
                    };
                    records.Add(element);
                }
            }
            return records;
        }

        public static List<History> SelectByReaderId(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var records = new List<History>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from history where readerId = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new History()
                    {
                        Id = (int)row["id"],
                        Book = BooksRepository.SelectById((int)row["booksId"]),
                        Reader = ReaderRepository.SelectById((int)row["readerId"])[0],
                        DateFrom = Convert.ToDateTime(row["dateFrom"].ToString()),
                        DateTo = Convert.ToDateTime(row["dateTo"].ToString())
                    };
                    records.Add(element);
                }
            }
            return records;
        }

        public static int Insert(History history)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into history " +
                    $"(booksId, readerId, dateFrom, dateTo) " +
                    $"values({history.Book.Id}, {history.Reader.Id}, " +
                    $"N'{history.DateFrom.ToString("yyyy-MM-dd")}', " +
                    $"N'{history.DateTo.ToString("yyyy-MM-dd")}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

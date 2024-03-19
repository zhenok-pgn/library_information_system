using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastracture;
using Library.Infrastructure;

namespace Library.Domain
{
    public class Genre : ValueType<Genre>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("Название")]
        public string Name { set; get; }
        [Label("Категоря")]
        public string Category { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class GenreRepository
    {
        public static List<Genre> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from genre", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Genre()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"],
                        Category = (string)row["category"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static List<Genre> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from genre where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Genre()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"],
                        Category = (string)row["category"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static List<string> SelectCategories()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select category from genre group by category", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add((string)row["category"]);
                }
            }
            return list;
        }

        public static int Delete(Genre obj)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from genre where id = {obj.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(Genre genre)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into genre " +
                    $"(name, category) " +
                    $"values(N'{genre.Name}', N'{genre.Category}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(Genre genre)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update genre " +
                    $"set name = N'{genre.Name}', category = N'{genre.Category}'" +
                    $"where id = {genre.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

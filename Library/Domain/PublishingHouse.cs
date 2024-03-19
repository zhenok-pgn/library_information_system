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
    public class PublishingHouse : ValueType<PublishingHouse>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("Название")]
        public string Name { set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class PublishingRepository
    {
        public static List<PublishingHouse> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var publishings = new List<PublishingHouse>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from publishingHouse", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var publish = new PublishingHouse()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"]
                    };
                    publishings.Add(publish);
                }
            }
            return publishings;
        }

        public static List<PublishingHouse> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<PublishingHouse>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from publishingHouse where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new PublishingHouse()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static int Delete(PublishingHouse obj)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from publishingHouse where id = {obj.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(PublishingHouse publishing)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into publishingHouse " +
                    $"(name) " +
                    $"values(N'{publishing.Name}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(PublishingHouse publishing)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update publishingHouse " +
                    $"set name = N'{publishing.Name}'" +
                    $"where id = {publishing.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

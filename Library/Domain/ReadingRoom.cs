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
    public class ReadingRoom : ValueType<ReadingRoom>
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

    public class ReadingRoomRepository
    {
        public static List<ReadingRoom> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<ReadingRoom>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from readingRoom", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new ReadingRoom()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static int Delete(ReadingRoom obj)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from readingRoom where id = {obj.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(ReadingRoom room)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into readingRoom " +
                    $"(name) " +
                    $"values(N'{room.Name}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(ReadingRoom room)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update readingRoom " +
                    $"set name = N'{room.Name}'" +
                    $"where id = {room.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

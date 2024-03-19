using System.Collections.Generic;
using Library.Infrastructure;
using Library.Infrastracture;
using System.Data.SqlClient;
using System.Data;

namespace Library.Domain
{
    public class Author : ValueType<Author>
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

    public class AuthorRepository
    {
        public static List<Author> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var authors = new List<Author>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from author", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var author = new Author()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"]                       
                    };
                    authors.Add(author);
                }
            }
            return authors;
        }

        public static List<Author> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Author>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from Author where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Author()
                    {
                        Id = (int)row["id"],
                        Name = (string)row["name"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static int Delete(Author obj)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from author where id = {obj.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(Author author)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into author " +
                    $"(name) " +
                    $"values(N'{author.Name}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(Author author)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update author " +
                    $"set name = N'{author.Name}'" +
                    $"where id = {author.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }

    public class RepositoryAuthor : IRepository<Author>
    {
        public int DeleteById(int id)
        {
            return AuthorRepository.Delete(new Author { Id = id });
        }

        public int Insert(Author record)
        {
            return AuthorRepository.Insert(record);
        }

        public List<Author> SelectAll()
        {
            return AuthorRepository.SelectAll();
        }

        public Author SelectById(int id)
        {
            var items = AuthorRepository.SelectById(id);
            if (items.Count == 0)
                return null;
            return items[0];
        }

        public int Update(Author record)
        {
            return AuthorRepository.Update(record);
        }
    }
}

using System.Collections.Generic;
using Library.Infrastracture;
using System.Data.SqlClient;
using System.Data;

namespace Library.Domain
{
    public static class ListOfAuthorsExtention
    {
        public static bool IsAuthorsTheSame<T>(this List<T> thisAuthors, List<T> thatAuthors)
            where T : Author
        {
            foreach (var a in thisAuthors)
                foreach (var b in thatAuthors)
                    if (a.Id != b.Id)
                        return false;
            return true;
        }
    }

    public class AuthorsRepository
    {
        public static List<Author> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var authors = new List<Author>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from authors where bookId = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                    authors.Add(new RepositoryAuthor().SelectById((int)row["authorId"]));
            }
            return authors;
        }

        public static int Insert(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (book.Id == 0)
                {
                    SqlCommand command1 = new SqlCommand("select max(id) from book", sqlConnection);
                    book.Id = (int)command1.ExecuteScalar();
                }
                var values = "";
                for (int i = 0; i < book.Authors.Count; i++)
                {
                    if (i == book.Authors.Count - 1)
                        values += $"({book.Authors[i].Id}, {book.Id})";
                    else
                        values += $"({book.Authors[i].Id}, {book.Id}), ";
                }

                SqlCommand command2 = new SqlCommand($"insert into authors " +
                    $"values {values}", sqlConnection);
                
                int affectedRows = command2.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Delete(int bookId)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from authors where bookId = {bookId}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

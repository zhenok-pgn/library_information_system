using System;
using System.Collections.Generic;
using Library.Infrastructure;
using Library.Infrastracture;
using System.Data.SqlClient;
using System.Data;

namespace Library.Domain
{
    public class Books : ValueType<Books>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("Книга")]
        public Book Book { set; get; }
        [Label("Читальный зал")]
        public ReadingRoom Room { set; get; }
        [Label("Статус")]
        public string Status { set; get; }

        public override string ToString()
        {
            return Book.ToString();
        }
    }

    public class BooksRepository
    {
        /*public static List<Book> SelectAll()
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from book", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var book = new Book()
                    {
                        Id = (int)row["id"],
                        Isbn = (string)row["isbn"],
                        Name = (string)row["name"],
                        Authors = AuthorsRepository.SelectById((int)row["id"]),
                        PublishingHouse = PublishingRepository.SelectById((int)row["publishingHouseId"])[0],
                        Year = (string)row["year"],
                        Pages = (string)row["pages"],
                        Genre = GenreRepository.SelectById((int)row["genreId"])[0],
                        Annotation = (string)row["annotation"]
                    };
                    books.Add(book);
                }
            }
            return books;
        }

        public static int Delete(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from book where id = {book.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }*/

        public static List<Books> SelectByRoomAndBook(int bookId, int roomId)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var books = new List<Books>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from books " +
                    $"inner join readingRoom on books.roomId = readingRoom.Id " +
                    $"where roomId = {roomId} and bookId = {bookId}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                var book = BookRepository.SelectById(bookId)[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    var hist = HistoryRepository.SelectByBookId((int)row["id"]);
                    var date = hist.Count == 0 ? DateTime.MinValue : hist[0].DateTo;
                    var bookCopy = new Books()
                    {
                        Id = (int)row["id"],
                        Book = book,
                        Room = new ReadingRoom {Id = (int)row["roomId"], Name = (string)row["name"] },
                        Status = date >= DateTime.Now ? "Занята" : "Свободна"
                    };
                    books.Add(bookCopy);
                }
            }
            return books;
        }

        public static Books SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var book = new Books();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from books " +
                    $"where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                book.Id = id;
                book.Book = BookRepository.SelectById((int)dataTable.Rows[0]["bookId"])[0];
            }
            return book;
        }

        public static List<Books> SelectSimilar(Books book, Reader reader)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var books = BookRepository.SelectSimilar(book.Book);
            var readerHist = HistoryRepository.SelectByReaderId(reader.Id);
            foreach(var e in readerHist)
            {
                //books.Remove(e.Book.Book);
                for (int i = 0; i < books.Count; i++)
                    if (e.Book.Book.Name == books[i].Name && e.Book.Book.Authors.IsAuthorsTheSame(books[i].Authors))
                        books.RemoveAt(i);
            }

            var similarBooks = new List<Books>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (var e in books)
                {
                    var sqlDataAdapter = new SqlDataAdapter($"select * from books " +
                        $"inner join readingRoom on books.roomId = readingRoom.Id " +
                        $"where bookId = {e.Id}", connection);
                    var dataTable = new DataTable();
                    connection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    connection.Close();

                    //var book = BookRepository.SelectById(bookId)[0];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var hist = HistoryRepository.SelectByBookId((int)row["id"]);
                        var date = hist.Count == 0 ? DateTime.MinValue : hist[0].DateTo;
                        var bookCopy = new Books()
                        {
                            Id = (int)row["id"],
                            Book = e,
                            Room = new ReadingRoom { Id = (int)row["roomId"], Name = (string)row["name"] },
                            Status = date >= DateTime.Now ? "Занята" : "Свободна"
                        };
                        if(bookCopy.Status == "Свободна")
                            similarBooks.Add(bookCopy);
                    }
                }
            }
            return similarBooks;
        }

        public static List<Books> SelectAdditional(Books book, Reader reader)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var books = BookRepository.SelectAdditional(book.Book);
            var readerHist = HistoryRepository.SelectByReaderId(reader.Id);
            foreach (var e in readerHist)
            {
                for (int i = 0; i < books.Count; i++)
                    if (e.Book.Book.Name == books[i].Name && e.Book.Book.Authors.IsAuthorsTheSame(books[i].Authors))
                        books.RemoveAt(i);
            }

            var similarBooks = new List<Books>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (var e in books)
                {
                    var sqlDataAdapter = new SqlDataAdapter($"select * from books " +
                        $"inner join readingRoom on books.roomId = readingRoom.Id " +
                        $"where bookId = {e.Id}", connection);
                    var dataTable = new DataTable();
                    connection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    connection.Close();

                    //var book = BookRepository.SelectById(bookId)[0];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var hist = HistoryRepository.SelectByBookId((int)row["id"]);
                        var date = hist.Count == 0 ? DateTime.MinValue : hist[0].DateTo;
                        var bookCopy = new Books()
                        {
                            Id = (int)row["id"],
                            Book = e,
                            Room = new ReadingRoom { Id = (int)row["roomId"], Name = (string)row["name"] },
                            Status = date >= DateTime.Now ? "Занята" : "Свободна"
                        };
                        if (bookCopy.Status == "Свободна")
                            similarBooks.Add(bookCopy);
                    }
                }
            }
            return similarBooks;
        }

        public static int Insert(Book book, ReadingRoom room,  int count = 1)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            if (count < 1)
                return 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                if (book.Id == 0)
                {
                    SqlCommand command1 = new SqlCommand("select max(id) from book", sqlConnection);
                    book.Id = (int)command1.ExecuteScalar();
                }
                var values = "";
                for (int i = 0; i < count; i++)
                {
                    if (i == count - 1)
                        values += $"({book.Id}, {room.Id})";
                    else
                        values += $"({book.Id}, {room.Id}), ";
                }
                SqlCommand command2 = new SqlCommand($"insert into books " +
                    $"(bookId, roomId) " +
                    $"values {values}", sqlConnection);

                int affectedRows = command2.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Delete(Books book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"delete from books where id = {book.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }
    }
}

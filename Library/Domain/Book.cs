using System;
using System.Collections.Generic;
using Library.Infrastructure;
using Library.Infrastracture;
using System.Data.SqlClient;
using System.Data;

namespace Library.Domain
{
    public class Book : ValueType<Book>
    {
        [Label("ID")]
        public int Id { set; get; }
        [Label("ISBN")]
        public string Isbn { set; get; }
        [Label("Название")]
        public string Name { set; get; }
        [Label("Авторы")]
        public List<Author> Authors { set; get; }
        [Label("Издательство")]
        public PublishingHouse PublishingHouse { set; get; }
        [Label("Год")]
        public string Year { set; get; }
        [Label("Количество страниц")]
        public string Pages { set; get; }
        [Label("Жанр")]
        public Genre Genre { set; get; }
        [Label("Аннотация")]
        public string Annotation { set; get; }

        public override string ToString()
        {
            return $"{Isbn}; '{Name}'; {Authors}; Издательство '{PublishingHouse}'; {Year} год; {Pages} стр.";
        }
    }

    public class BookRepository
    {
        public static List<Book> SelectAll()
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
                    var book = new Book() {
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

        public static List<Book> SelectById(int id)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from book where id = {id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var element = new Book()
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
                    list.Add(element);
                }
            }
            return list;
        }

        public static List<Book> SelectSimilar(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from book where genreId = {book.Genre.Id}", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var authors = AuthorsRepository.SelectById((int)row["id"]);
                    var dist = JaroWinklerDistance.distance(book.Name, (string)row["name"]);
                    if (authors.IsAuthorsTheSame(book.Authors) || dist > 0.45)
                        continue;
                    var element = new Book()
                    {
                        Id = (int)row["id"],
                        Isbn = (string)row["isbn"],
                        Name = (string)row["name"],
                        Authors = authors,
                        PublishingHouse = PublishingRepository.SelectById((int)row["publishingHouseId"])[0],
                        Year = (string)row["year"],
                        Pages = (string)row["pages"],
                        Genre = GenreRepository.SelectById((int)row["genreId"])[0],
                        Annotation = (string)row["annotation"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static List<Book> SelectAdditional(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            var list = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sqlDataAdapter = new SqlDataAdapter($"select * from book where genreId in " +
                    $"(select id from genre where category = N'{book.Genre.Category}')", connection);
                var dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    var authors = AuthorsRepository.SelectById((int)row["id"]);
                    if (authors.IsAuthorsTheSame(book.Authors) && book.Name == (string)row["name"])
                        continue;
                    var element = new Book()
                    {
                        Id = (int)row["id"],
                        Isbn = (string)row["isbn"],
                        Name = (string)row["name"],
                        Authors = authors,
                        PublishingHouse = PublishingRepository.SelectById((int)row["publishingHouseId"])[0],
                        Year = (string)row["year"],
                        Pages = (string)row["pages"],
                        Genre = GenreRepository.SelectById((int)row["genreId"])[0],
                        Annotation = (string)row["annotation"]
                    };
                    list.Add(element);
                }
            }
            return list;
        }

        public static int Delete(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                AuthorsRepository.Delete(book.Id);
                SqlCommand command = new SqlCommand($"delete from book where id = {book.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Insert(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"insert into book " +
                    $"(isbn, name, publishingHouseId, year, pages, genreId, annotation) " +
                    $"values(N'{book.Isbn}', N'{book.Name}', {book.PublishingHouse.Id}, " +
                    $"N'{book.Year}', N'{book.Pages}', {book.Genre.Id}, N'{book.Annotation}')", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();
                return affectedRows;
            }
        }

        public static int Update(Book book)
        {
            string connectionString = Properties.Settings.Default.LibraryDBConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"update book " +
                    $"set isbn = N'{book.Isbn}', " +
                    $"name = N'{book.Name}', publishingHouseId = {book.PublishingHouse.Id}, " +
                    $"year = N'{book.Year}', pages = N'{book.Pages}', genreId = {book.Genre.Id}, " +
                    $"annotation = N'{book.Annotation}' " +
                    $"where id = {book.Id}", sqlConnection);

                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                sqlConnection.Close();

                AuthorsRepository.Delete(book.Id);
                AuthorsRepository.Insert(book);
                return affectedRows;
            }
        }
    }

    public class RepositoryBook : IRepository<Book>
    {
        public int DeleteById(int id)
        {
            return BookRepository.Delete(new Book { Id = id });
        }

        public int Insert(Book record)
        {
            return BookRepository.Insert(record);
        }

        public List<Book> SelectAll()
        {
            return BookRepository.SelectAll();
        }

        public Book SelectById(int id)
        {
            var items = BookRepository.SelectById(id);
            if (items.Count == 0)
                return null;
            return items[0];
        }

        public int Update(Book record)
        {
            return BookRepository.Update(record);
        }
    }

    public static class JaroWinklerDistance
    {
        /* The Winkler modification will not be applied unless the 
         * percent match was at or above the mWeightThreshold percent 
         * without the modification. 
         * Winkler's paper used a default value of 0.7
         */
        private static readonly double mWeightThreshold = 0.7;

        /* Size of the prefix to be concidered by the Winkler modification. 
         * Winkler's paper used a default value of 4
         */
        private static readonly int mNumChars = 4;


        /// <summary>
        /// Returns the Jaro-Winkler distance between the specified  
        /// strings. The distance is symmetric and will fall in the 
        /// range 0 (perfect match) to 1 (no match). 
        /// </summary>
        /// <param name="aString1">First String</param>
        /// <param name="aString2">Second String</param>
        /// <returns></returns>
        public static double distance(string aString1, string aString2)
        {
            return 1.0 - proximity(aString1, aString2);
        }


        /// <summary>
        /// Returns the Jaro-Winkler distance between the specified  
        /// strings. The distance is symmetric and will fall in the 
        /// range 0 (no match) to 1 (perfect match). 
        /// </summary>
        /// <param name="aString1">First String</param>
        /// <param name="aString2">Second String</param>
        /// <returns></returns>
        public static double proximity(string aString1, string aString2)
        {
            int lLen1 = aString1.Length;
            int lLen2 = aString2.Length;
            if (lLen1 == 0)
                return lLen2 == 0 ? 1.0 : 0.0;

            int lSearchRange = Math.Max(0, Math.Max(lLen1, lLen2) / 2 - 1);

            // default initialized to false
            bool[] lMatched1 = new bool[lLen1];
            bool[] lMatched2 = new bool[lLen2];

            int lNumCommon = 0;
            for (int i = 0; i < lLen1; ++i)
            {
                int lStart = Math.Max(0, i - lSearchRange);
                int lEnd = Math.Min(i + lSearchRange + 1, lLen2);
                for (int j = lStart; j < lEnd; ++j)
                {
                    if (lMatched2[j]) continue;
                    if (aString1[i] != aString2[j])
                        continue;
                    lMatched1[i] = true;
                    lMatched2[j] = true;
                    ++lNumCommon;
                    break;
                }
            }
            if (lNumCommon == 0) return 0.0;

            int lNumHalfTransposed = 0;
            int k = 0;
            for (int i = 0; i < lLen1; ++i)
            {
                if (!lMatched1[i]) continue;
                while (!lMatched2[k]) ++k;
                if (aString1[i] != aString2[k])
                    ++lNumHalfTransposed;
                ++k;
            }
            // System.Diagnostics.Debug.WriteLine("numHalfTransposed=" + numHalfTransposed);
            int lNumTransposed = lNumHalfTransposed / 2;

            // System.Diagnostics.Debug.WriteLine("numCommon=" + numCommon + " numTransposed=" + numTransposed);
            double lNumCommonD = lNumCommon;
            double lWeight = (lNumCommonD / lLen1
                             + lNumCommonD / lLen2
                             + (lNumCommon - lNumTransposed) / lNumCommonD) / 3.0;

            if (lWeight <= mWeightThreshold) return lWeight;
            int lMax = Math.Min(mNumChars, Math.Min(aString1.Length, aString2.Length));
            int lPos = 0;
            while (lPos < lMax && aString1[lPos] == aString2[lPos])
                ++lPos;
            if (lPos == 0) return lWeight;
            return lWeight + 0.1 * lPos * (1.0 - lWeight);

        }


    }
}

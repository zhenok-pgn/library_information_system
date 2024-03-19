using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Domain;

namespace Library.UserInterface
{
    public partial class AddBookForm : Form
    {
        Book book;

        public AddBookForm(Book book = null)
        {
            InitializeComponent();
            PrepairForm(book);
        }

        private void PrepairForm(Book book)
        {
            if (book == null)
            {
                FillComponent(checkedListBox1, AuthorRepository.SelectAll);
                FillComponent(comboBox1, PublishingRepository.SelectAll);
                FillComponent(comboBox2, GenreRepository.SelectAll);
                FillComponent(comboBox3, ReadingRoomRepository.SelectAll);
                AddBookCopyButton.Click += AddBookCopyButton_Click;
            }
            else
            {
                this.book = book;
                label9.Visible = false;
                label10.Visible = false;
                comboBox3.Visible = false;
                numericUpDown3.Visible = false;

                textBox1.Text = book.Isbn;
                textBox2.Text = book.Name;
                textBox8.Text = book.Annotation;

                FillComponent(checkedListBox1, AuthorRepository.SelectAll);
                FillComponent(comboBox1, PublishingRepository.SelectAll);
                FillComponent(comboBox2, GenreRepository.SelectAll);
                FillComponent(comboBox3, ReadingRoomRepository.SelectAll);

                comboBox1.SelectedValue = book.PublishingHouse.Id;
                comboBox2.SelectedValue = book.Genre.Id;
                numericUpDown1.Value = int.Parse(book.Year);
                numericUpDown2.Value = int.Parse(book.Pages);
                AddBookCopyButton.Click += UpdateBookCopyButton_Click;
            }
        }

        private void FillComponent<T>(CheckedListBox box, Func<List<T>> getDataFromRepository)
        {
            try
            {
                var dataTable = getDataFromRepository();
                if (dataTable.Count != 0)
                {
                    box.DataSource = dataTable;
                    box.ValueMember = "Id";
                    box.DisplayMember = "Name";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FillComponent<T>(ComboBox box, Func<List<T>> getDataFromRepository)
        {
            try
            {
                var dataTable = getDataFromRepository();
                if (dataTable.Count != 0)
                {
                    box.DataSource = dataTable;
                    box.ValueMember = "Id";
                    box.DisplayMember = "Name";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddBookCopyButton_Click(object sender, EventArgs e)
        {
            var checkedItems = checkedListBox1.CheckedItems;
            var authors = new List<Author>();
            foreach (Author author in checkedItems)
                authors.Add(author);

            var book = new Book
            {
                Isbn = textBox1.Text,
                Name = textBox2.Text,
                PublishingHouse = comboBox1.SelectedItem as PublishingHouse,
                Year = Convert.ToString(numericUpDown1.Value),
                Pages = Convert.ToString(numericUpDown2.Value),
                Genre = comboBox2.SelectedItem as Genre,
                Annotation = textBox8.Text,
                Authors = authors
            };

            

            var room = comboBox3.SelectedItem as ReadingRoom;

            try
            {
                BookRepository.Insert(book);
                AuthorsRepository.Insert(book);
                BooksRepository.Insert(book, room, (int)numericUpDown3.Value);
                const string message =
                "Данные успешно добавлены";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UpdateBookCopyButton_Click(object sender, EventArgs e)
        {
            book.Isbn = textBox1.Text;
            book.Name = textBox2.Text;
            book.PublishingHouse = comboBox1.SelectedItem as PublishingHouse;
            book.Year = Convert.ToString(numericUpDown1.Value);
            book.Pages = Convert.ToString(numericUpDown2.Value);
            book.Genre = comboBox2.SelectedItem as Genre;
            book.Annotation = textBox8.Text;

            var checkedItems = checkedListBox1.CheckedItems;
            var authors = new List<Author>();
            foreach (Author author in checkedItems)
                authors.Add(author);
            book.Authors = authors;

            try
            {
                BookRepository.Update(book);
                const string message =
                "Данные успешно добавлены";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Infrastracture;
using Library.Domain;
using Library.UserInterface;

namespace Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TableLoader.LoadTable(BookRepository.SelectAll, dataGridView1);
            TableLoader.SetTableHeaders(Book.Properties, dataGridView1);
            //dataGridView1.Load(new RepositoryBook().SelectAll());
        }


        private void AddBookButton_Click(object sender, EventArgs e)
        {
            new AddBookForm().ShowDialog();
            TableLoader.LoadTable(BookRepository.SelectAll, dataGridView1);
            TableLoader.SetTableHeaders(Book.Properties, dataGridView1);
        }

        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            const string message =
            "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
                BookRepository.Delete(record as Book);
                TableLoader.LoadTable(BookRepository.SelectAll, dataGridView1);
                TableLoader.SetTableHeaders(Book.Properties, dataGridView1);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void InfoBookButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку");
                return;
            }
            var record = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
            new InfoBookForm(record as Book).ShowDialog();
        }

        private void EditBookButton(object sender, EventArgs e)
        {
            var record = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
            new AddBookForm(record as Book).ShowDialog();
            TableLoader.LoadTable(BookRepository.SelectAll, dataGridView1);
            TableLoader.SetTableHeaders(Book.Properties, dataGridView1);
        }

        private void TabChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "books":
                    TableLoader.LoadTable(BookRepository.SelectAll, dataGridView1);
                    TableLoader.SetTableHeaders(Book.Properties, dataGridView1);
                    return;
                case "authors":
                    TableLoader.LoadTable(AuthorRepository.SelectAll, dataGridView3);
                    TableLoader.SetTableHeaders(Author.Properties, dataGridView3);
                    return;
                case "readers":
                    TableLoader.LoadTable(ReaderRepository.SelectAll, dataGridView2);
                    TableLoader.SetTableHeaders(Reader.Properties, dataGridView2);
                    return;
                case "genres":
                    TableLoader.LoadTable(GenreRepository.SelectAll, dataGridView4);
                    TableLoader.SetTableHeaders(Genre.Properties, dataGridView4);
                    return;
                case "publishings":
                    TableLoader.LoadTable(PublishingRepository.SelectAll, dataGridView5);
                    TableLoader.SetTableHeaders(PublishingHouse.Properties, dataGridView5);
                    return;
                case "rooms":
                    TableLoader.LoadTable(ReadingRoomRepository.SelectAll, dataGridView6);
                    TableLoader.SetTableHeaders(ReadingRoom.Properties, dataGridView6);
                    return;
                default:
                    return;
            }
        }

        private void AddReaderButton_Click(object sender, EventArgs e)
        {
            new AddReaderForm().ShowDialog();
            TableLoader.LoadTable(ReaderRepository.SelectAll, dataGridView2);
            TableLoader.SetTableHeaders(Reader.Properties, dataGridView2);
        }

        private void DeleteReaderButton_Click(object sender, EventArgs e)
        {
            const string message =
            "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView2.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView2.DataSource as BindingSource).List[dataGridView2.SelectedRows[0].Index];
                ReaderRepository.Delete(record as Reader);
                TableLoader.LoadTable(ReaderRepository.SelectAll, dataGridView2);
                TableLoader.SetTableHeaders(Reader.Properties, dataGridView2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditReaderButton_Click(object sender, EventArgs e)
        {
            var record = (dataGridView2.DataSource as BindingSource).List[dataGridView2.SelectedRows[0].Index];
            new AddReaderForm(record as Reader).ShowDialog();
            TableLoader.LoadTable(ReaderRepository.SelectAll, dataGridView2);
            TableLoader.SetTableHeaders(Reader.Properties, dataGridView2);
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            new AddAuthorForm().ShowDialog();
            TableLoader.LoadTable(AuthorRepository.SelectAll, dataGridView3);
            TableLoader.SetTableHeaders(Author.Properties, dataGridView3);
        }

        private void DeleteAuthorButton_Click(object sender, EventArgs e)
        {
            const string message =
            "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView3.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView3.DataSource as BindingSource).List[dataGridView3.SelectedRows[0].Index];
                AuthorRepository.Delete(record as Author);
                TableLoader.LoadTable(AuthorRepository.SelectAll, dataGridView3);
                TableLoader.SetTableHeaders(Author.Properties, dataGridView3);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditAuthorButton_Click(object sender, EventArgs e)
        {
            var record = (dataGridView3.DataSource as BindingSource).List[dataGridView3.SelectedRows[0].Index];
            new AddAuthorForm(record as Author).ShowDialog();
            TableLoader.LoadTable(AuthorRepository.SelectAll, dataGridView3);
            TableLoader.SetTableHeaders(Author.Properties, dataGridView3);
        }

        private void AddGenreButton_Click(object sender, EventArgs e)
        {
            new AddGenreForm().ShowDialog();
            TableLoader.LoadTable(GenreRepository.SelectAll, dataGridView4);
            TableLoader.SetTableHeaders(Genre.Properties, dataGridView4);
        }

        private void DeleteGenreButton_Click(object sender, EventArgs e)
        {
            const string message =
             "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView4.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView4.DataSource as BindingSource).List[dataGridView4.SelectedRows[0].Index];
                GenreRepository.Delete(record as Genre);
                TableLoader.LoadTable(GenreRepository.SelectAll, dataGridView4);
                TableLoader.SetTableHeaders(Genre.Properties, dataGridView4);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditGenreButton_Click(object sender, EventArgs e)
        {
            var record = (dataGridView4.DataSource as BindingSource).List[dataGridView4.SelectedRows[0].Index];
            new AddGenreForm(record as Genre).ShowDialog();
            TableLoader.LoadTable(GenreRepository.SelectAll, dataGridView4);
            TableLoader.SetTableHeaders(Genre.Properties, dataGridView4);
        }

        private void AddPublishingButton_Click(object sender, EventArgs e)
        {
            new AddPublishingForm().ShowDialog();
            TableLoader.LoadTable(PublishingRepository.SelectAll, dataGridView5);
            TableLoader.SetTableHeaders(PublishingHouse.Properties, dataGridView5);
        }

        private void DeletePublishingButton_Click(object sender, EventArgs e)
        {
            const string message =
             "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView5.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView5.DataSource as BindingSource).List[dataGridView5.SelectedRows[0].Index];
                PublishingRepository.Delete(record as PublishingHouse);
                TableLoader.LoadTable(PublishingRepository.SelectAll, dataGridView5);
                TableLoader.SetTableHeaders(PublishingHouse.Properties, dataGridView5);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditPublishingButton_Click(object sender, EventArgs e)
        {
            var record = (dataGridView5.DataSource as BindingSource).List[dataGridView5.SelectedRows[0].Index];
            new AddPublishingForm(record as PublishingHouse).ShowDialog();
            TableLoader.LoadTable(PublishingRepository.SelectAll, dataGridView5);
            TableLoader.SetTableHeaders(PublishingHouse.Properties, dataGridView5);
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            new AddReadingRoomForm().ShowDialog();
            TableLoader.LoadTable(ReadingRoomRepository.SelectAll, dataGridView6);
            TableLoader.SetTableHeaders(ReadingRoom.Properties, dataGridView6);
        }

        private void DeleteRoomButton_Click(object sender, EventArgs e)
        {
            const string message =
             "Вы действительно хотите удалить запись?";
            const string caption = "Удаление";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                if (dataGridView6.SelectedRows.Count != 1)
                    MessageBox.Show("Выберите одну строку");
                var record = (dataGridView6.DataSource as BindingSource).List[dataGridView6.SelectedRows[0].Index];
                ReadingRoomRepository.Delete(record as ReadingRoom);
                TableLoader.LoadTable(ReadingRoomRepository.SelectAll, dataGridView6);
                TableLoader.SetTableHeaders(ReadingRoom.Properties, dataGridView6);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditRoomButton_Click(object sender, EventArgs e)
        {
            var record = (dataGridView6.DataSource as BindingSource).List[dataGridView6.SelectedRows[0].Index];
            new AddReadingRoomForm(record as ReadingRoom).ShowDialog();
            TableLoader.LoadTable(ReadingRoomRepository.SelectAll, dataGridView6);
            TableLoader.SetTableHeaders(ReadingRoom.Properties, dataGridView6);
        }
    }
}

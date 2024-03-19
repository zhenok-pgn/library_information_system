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
    public partial class InfoBookForm : Form
    {
        Book book;

        public InfoBookForm(Book book)
        {
            InitializeComponent();
            this.book = book;
            PrepairForm();
        }

        private void PrepairForm()
        {
            FillComponent(toolStripComboBox1, ReadingRoomRepository.SelectAll);
        }

        private void FillComponent<T>(ToolStripComboBox box, Func<List<T>> getDataFromRepository)
        {
            try
            {
                var dataTable = getDataFromRepository();
                if (dataTable.Count != 0)
                {
                    box.ComboBox.ValueMember = "Id";
                    box.ComboBox.DisplayMember = "Name";
                    box.ComboBox.DataSource = dataTable;
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //private void FillComponent<T>(DataGridView box,int bookId, int roomId, Func<int, int, List<T>> getDataFromRepository)
        //{
        //    try
        //    {
        //        var table = getDataFromRepository(bookId, roomId);
        //        BindingSource bindingSource = new BindingSource();
        //        bindingSource.DataSource = table;
        //        box.DataSource = bindingSource;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}

        private void ReadingRoomChanged(object sender, EventArgs e)
        {
            //FillComponent(dataGridView1, book.Id, (int)toolStripComboBox1.ComboBox.SelectedValue, BooksRepository.SelectByRoomAndBook);
            TableLoader.LoadTable(book.Id, (int)toolStripComboBox1.ComboBox.SelectedValue, BooksRepository.SelectByRoomAndBook, dataGridView1);
            TableLoader.SetTableHeaders(Books.Properties, dataGridView1);
        }

        private void BookCopyInfoButton(object sender, EventArgs e)
        {
            var record = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
            new BookHistoryForm(record as Books).ShowDialog();
        }

        private void AddBookCopyButton(object sender, EventArgs e)
        {
            var room = toolStripComboBox1.ComboBox.SelectedItem as ReadingRoom;
            new AddBookCopyForm(book, room).ShowDialog();
            TableLoader.LoadTable(book.Id, (int)toolStripComboBox1.ComboBox.SelectedValue, BooksRepository.SelectByRoomAndBook, dataGridView1);
            TableLoader.SetTableHeaders(Books.Properties, dataGridView1);
        }

        private void TakeBookButton(object sender, EventArgs e)
        {
            var record = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
            if ((record as Books).Status == "Свободна")
            {
                new TakeBookForm(record as Books).ShowDialog();
                TableLoader.LoadTable(book.Id, (int)toolStripComboBox1.ComboBox.SelectedValue, BooksRepository.SelectByRoomAndBook, dataGridView1);
                TableLoader.SetTableHeaders(Books.Properties, dataGridView1);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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
                BooksRepository.Delete(record as Books);
                TableLoader.LoadTable(book.Id, (int)toolStripComboBox1.ComboBox.SelectedValue, BooksRepository.SelectByRoomAndBook, dataGridView1);
                TableLoader.SetTableHeaders(Books.Properties, dataGridView1);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

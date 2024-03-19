using Library.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UserInterface
{
    public partial class RecommendationForm : Form
    {
        Reader reader;
        Books book;

        public RecommendationForm(Reader reader, Books book)
        {
            InitializeComponent();
            this.book = book;
            this.reader = reader;
            PrepairForm();         
        }

        private void PrepairForm()
        {
            TableLoader.LoadTable(book, reader, BooksRepository.SelectSimilar, dataGridView1);
            TableLoader.LoadTable(book, reader, BooksRepository.SelectAdditional, dataGridView2);
            TableLoader.SetTableHeaders(Books.Properties, dataGridView1);
            TableLoader.SetTableHeaders(Books.Properties, dataGridView2);
        }

        private void AdditionalButton_Click(object sender, EventArgs e)
        {
            var selectedBook = (dataGridView2.DataSource as BindingSource).List[dataGridView2.SelectedRows[0].Index];
            var record = new History
            {
                Book = selectedBook as Books,
                Reader = reader,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(7)
            };
            try
            {
                HistoryRepository.Insert(record);
                const string message =
                "Данные успешно добавлены";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                //TableLoader.LoadTable(book, reader, BooksRepository.SelectAdditional, dataGridView2);
                TableLoader.LoadTable(book, reader, BooksRepository.SelectSimilar, dataGridView1);
                TableLoader.LoadTable(book, reader, BooksRepository.SelectAdditional, dataGridView2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AlternativeButton_Click(object sender, EventArgs e)
        {
            var selectedBook = (dataGridView1.DataSource as BindingSource).List[dataGridView1.SelectedRows[0].Index];
            var record = new History
            {
                Book = selectedBook as Books,
                Reader = reader,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(7)
            };
            try
            {
                HistoryRepository.Insert(record);
                const string message =
                "Данные успешно добавлены";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                //TableLoader.LoadTable(book, reader, BooksRepository.SelectSimilar, dataGridView1);
                TableLoader.LoadTable(book, reader, BooksRepository.SelectSimilar, dataGridView1);
                TableLoader.LoadTable(book, reader, BooksRepository.SelectAdditional, dataGridView2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

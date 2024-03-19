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
    public partial class BookHistoryForm : Form
    {
        Books books;

        public BookHistoryForm(Books books)
        {
            InitializeComponent();
            this.books = books;
            PrepairForm();
        }

        private void PrepairForm()
        {
            TableLoader.LoadTable(books.Id, HistoryRepository.SelectByBookId, dataGridView1);
            TableLoader.SetTableHeaders(History.Properties, dataGridView1);
        }
    }
}

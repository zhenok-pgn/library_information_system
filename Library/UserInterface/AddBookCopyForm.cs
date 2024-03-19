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
    public partial class AddBookCopyForm : Form
    {
        Book book;
        ReadingRoom room;

        public AddBookCopyForm(Book book, ReadingRoom room)
        {
            InitializeComponent();
            this.book = book;
            this.room = room;
        }

        private void AddBookCopyButton(object sender, EventArgs e)
        {
            try
            {
                BooksRepository.Insert(book, room, (int)numericUpDown1.Value);
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

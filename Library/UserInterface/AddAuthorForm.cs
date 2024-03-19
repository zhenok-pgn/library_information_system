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
    public partial class AddAuthorForm : Form
    {
        Author author;

        public AddAuthorForm(Author author = null)
        {
            InitializeComponent();
            PrepairForm(author);
        }

        private void PrepairForm(Author author)
        {
            if (author == null)
            {
                button1.Click += AddAuthorButton_Click;
            }
            else
            {
                this.author = author;

                textBox1.Text = author.Name;
                button1.Click += UpdateAuthorButton_Click;
            }
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            var author = new Author
            {
                Name = textBox1.Text
            };

            try
            {
                AuthorRepository.Insert(author);
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

        private void UpdateAuthorButton_Click(object sender, EventArgs e)
        {
            author.Name = textBox1.Text;

            try
            {
                AuthorRepository.Update(author);
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

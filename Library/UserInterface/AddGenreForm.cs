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
    public partial class AddGenreForm : Form
    {
        public AddGenreForm(Genre genre = null)
        {
            InitializeComponent();
            PrepairForm(genre);
        }

        Genre genre;

        private void PrepairForm(Genre genre)
        {
            FillComponent(comboBox1, GenreRepository.SelectCategories);
            if (genre == null)
            {
                button1.Click += AddGenreButton_Click;
            }
            else
            {
                this.genre = genre;

                textBox1.Text = genre.Name;
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(genre.Category);
                button1.Click += UpdateGenreButton_Click;
            }
        }

        private void FillComponent<T>(ComboBox box, Func<List<T>> getDataFromRepository)
        {
            try
            {
                var dataTable = getDataFromRepository();
                if (dataTable.Count != 0)
                {
                    foreach (var item in dataTable)
                        box.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddGenreButton_Click(object sender, EventArgs e)
        {
            var genre = new Genre
            {
                Name = textBox1.Text,
                Category = comboBox1.SelectedItem as string
            };

            try
            {
                GenreRepository.Insert(genre);
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

        private void UpdateGenreButton_Click(object sender, EventArgs e)
        {
            genre.Name = textBox1.Text;
            genre.Category = comboBox1.SelectedItem as string;

            try
            {
                GenreRepository.Update(genre);
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

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            new AddCategoryForm(comboBox1).ShowDialog();
        }
    }
}

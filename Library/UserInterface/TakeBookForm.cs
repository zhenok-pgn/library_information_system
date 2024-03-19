using Library.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Library.UserInterface
{
    public partial class TakeBookForm : Form
    {
        Books book;

        public TakeBookForm(Books book)
        {
            InitializeComponent();
            this.book = book;
            PrepairForm();
        }

        private void PrepairForm()
        {
            FillComponent(comboBox1, ReaderRepository.SelectAll);
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

        private void ApplyButton(object sender, EventArgs e)
        {
            var record = new History
            {
                Book = book,
                Reader = comboBox1.SelectedItem as Reader,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(7)
            };

            try
            {
                HistoryRepository.Insert(record);
                const string message =
                "Данные успешно добавлены\nХотите получить посмотреть похожую литературу?";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    new RecommendationForm(comboBox1.SelectedItem as Reader, book).ShowDialog();                 
                }
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

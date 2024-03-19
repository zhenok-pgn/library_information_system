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
    public partial class AddReaderForm : Form
    {
        Reader reader;

        public AddReaderForm(Reader reader = null)
        {
            InitializeComponent();
            PrepairForm(reader);
        }

        private void PrepairForm(Reader reader)
        {
            if (reader == null)
            {          
                button1.Click += AddReaderButton_Click;
            }
            else
            {
                this.reader = reader;

                textBox1.Text = reader.Name;
                textBox2.Text = reader.Passport;
                textBox3.Text = reader.Phone;
                textBox4.Text = reader.Adress;
                button1.Click += UpdateReaderButton_Click;
            }
        }

        private void AddReaderButton_Click(object sender, EventArgs e)
        {
            var reader = new Reader
            {
                Name = textBox1.Text,
                Passport = textBox2.Text,
                Phone = textBox3.Text,
                Adress = textBox4.Text
            };

            try
            {
                ReaderRepository.Insert(reader);
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

        private void UpdateReaderButton_Click(object sender, EventArgs e)
        {
            reader.Name = textBox1.Text;
            reader.Passport = textBox2.Text;
            reader.Phone = textBox3.Text;
            reader.Adress = textBox4.Text;

            try
            {
                ReaderRepository.Update(reader);
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

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
    public partial class AddPublishingForm : Form
    {
        public AddPublishingForm(PublishingHouse publishingHouse = null)
        {
            InitializeComponent();
            PrepairForm(publishingHouse);
        }

        PublishingHouse publishingHouse;

        private void PrepairForm(PublishingHouse publishingHouse)
        {
            if (publishingHouse == null)
            {
                button1.Click += AddPublishingButton_Click;
            }
            else
            {
                this.publishingHouse = publishingHouse;

                textBox1.Text = publishingHouse.Name;
                button1.Click += UpdatePublishingButton_Click;
            }
        }

        private void AddPublishingButton_Click(object sender, EventArgs e)
        {
            var publishing = new PublishingHouse
            {
                Name = textBox1.Text
            };

            try
            {
                PublishingRepository.Insert(publishing);
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

        private void UpdatePublishingButton_Click(object sender, EventArgs e)
        {
            publishingHouse.Name = textBox1.Text;

            try
            {
                PublishingRepository.Update(publishingHouse);
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
